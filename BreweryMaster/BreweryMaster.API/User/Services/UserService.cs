using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Helpers;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BreweryMaster.API.User.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IAddressService _addressService;

        public UserService(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context, 
            IAddressService addressService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _addressService = addressService;
        }

        public async Task<IEnumerable<UserResponse>?> GetUsers()
        {
            var response = new List<UserResponse>();

            var companyUsers = await _context.CompanyUsers.Include(x => x.DeliveryAddress).ToListAsync();
            var individualUsers = await _context.IndividualUsers.Include(x => x.DeliveryAddress).ToListAsync();

            response.AddRange(companyUsers.Select(x => new UserResponse()
            {
                Id = x.Id,
                PostCode = x.DeliveryAddress?.PostalCode,
                City = x.DeliveryAddress?.City,
                Email = x.Email,
                Name = x.CompanyName,
                IsCompany = true
            }));

            response.AddRange(individualUsers.Select(x => new UserResponse()
            {
                Id = x.Id,
                PostCode = x.DeliveryAddress?.PostalCode,
                City = x.DeliveryAddress?.City,
                Email = x.Email,
                Name = $"{x.Surname} {x.Forename}",
                IsCompany = false
            }));

            return response;
        }

        public async Task<UserResponse?> GetUserById(string id)
        {
            var userList = await GetUsers();

            var user = userList?.FirstOrDefault(x => x.Id == id);

            UserResponse userResponse = null!;

            if (user is not null)
            {
                userResponse = new UserResponse()
                {
                    Id = user.Id,
                    Email = user.Email
                };
            };

            return userResponse;
        }

        public async Task<UserResponse> GetCurrentUser(ClaimsPrincipal? user)
        {
            if (user is null)
                throw new Exception("user not found");

            if (user.Identity is null)
                throw new Exception("user identity not found");

            if (user.Identity.IsAuthenticated == false)
                throw new Exception("user not authenticated");

            var emailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var nameIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (emailClaim is null || nameIdClaim is null)
                throw new Exception("user claims not found");

            var roles =  await _context.UserRoles.Where(x => x.UserId == nameIdClaim.Value).Select(x => x.RoleId).ToListAsync();

            return new UserResponse()
            {
                Id = nameIdClaim.Value,
                Email = emailClaim.Value,
                Roles = roles,
            };
        }

        public async Task<ApplicationUser> CreateUser(UserRegisterRequest request)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                ApplicationUser userToCreate = null!;

                if (request.IsCompany)
                {
                    if (request.CompanyUserInfo is null)
                        throw new Exception();

                    userToCreate = new CompanyUser
                    {
                        UserName = request.UserAuthInfo.Email,
                        Email = request.UserAuthInfo.Email,
                        CompanyName = request.CompanyUserInfo.CompanyName,
                        Nip = request.CompanyUserInfo.Nip,
                    };
                }
                else
                {
                    if (request.IndividualUserInfo is null)
                        throw new Exception();

                    userToCreate = new IndividualUser
                    {
                        UserName = request.UserAuthInfo.Email,
                        Email = request.UserAuthInfo.Email,
                        Forename = request.IndividualUserInfo.Forename,
                        Surname = request.IndividualUserInfo.Surname,
                    };
                }

                var result = await _userManager.CreateAsync(userToCreate, request.UserAuthInfo.Password);

                if (!result.Succeeded)
                    throw new Exception();

                if (request.Address is not null)
                    _addressService.AddAddress(request.Address, userToCreate.Id);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return userToCreate;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

        public async Task<ApplicationUser> UpdateUser(UserUpdateRequest request, string userId)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new Exception();

            user.Email = request.Email;
            user.UserName = request.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new Exception();

            return user;
        }
        public async Task<bool> CreateTestUsers()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            foreach (var role in roles)
            {
                var userRequest = new UserRegisterRequest()
                {
                    UserAuthInfo = new UserRequest()
                    {
                        Email = $"{role.Id}@test.test",
                        Password = "Test123$",
                        ConfirmPassword = "Test123$"
                    },
                    IndividualUserInfo = new IndividualUserRequest()
                    {
                        Forename = role.Id,
                        Surname = role.Id
                    }
                };

                try
                {
                    var createdUser = await CreateUser(userRequest);
                    if (createdUser == null)
                        throw new Exception();

                    var result = await _userManager.AddToRolesAsync(createdUser, roles.GetRoles(role.Name));

                    if (!result.Succeeded)
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
