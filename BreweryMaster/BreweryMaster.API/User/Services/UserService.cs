using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Enums;
using BreweryMaster.API.User.Helpers;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.User.Models.Responses;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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

            var companyUsers = await _context.CompanyUsers.Include(x => x.UserAddresses).ToListAsync();
            var individualUsers = await _context.IndividualUsers.Include(x => x.UserAddresses).ToListAsync();

            response.AddRange(companyUsers.Select(x => new UserResponse()
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.CompanyName,
                IsCompany = true
            }));

            response.AddRange(individualUsers.Select(x => new UserResponse()
            {
                Id = x.Id,
                Email = x.Email,
                Name = $"{x.Surname} {x.Forename}",
                IsCompany = false
            }));

            return response;
        }

        public async Task<IEnumerable<EntityStringIdResponse>?> GetUserDropDownList()
        {
            var users = await GetUsers();

            return users?.Select(x => new EntityStringIdResponse()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public async Task<UserDetailsResponse?> GetUserById(string id)
        {

            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            var addresses = await _context.UserAddresses.Where(x => x.UserId == id).Include(x => x.Address).ToListAsync();
            var homeAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Home)?.Address.ToResponse();
            var deliveryAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Delivery)?.Address.ToResponse();
            var invoiceAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Invoice)?.Address.ToResponse();

            var response = new UserDetailsResponse()
            {
                Id = id,
                Email = user.Email,
                HomeAddress = homeAddress,
                DeliveryAddress = deliveryAddress,
            };

            user.SetDetailResponse(response);

            return response;
        }

        public async Task<UserResponse> GetCurrentUser(ClaimsPrincipal? user)
        {
            if (user is null)
                throw new ArgumentNullException("user not found");

            if (user.Identity is null)
                throw new ArgumentNullException("user identity not found");

            if (user.Identity.IsAuthenticated == false)
                throw new UnauthorizedAccessException("user not authenticated");

            var emailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var nameIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (emailClaim is null || nameIdClaim is null)
                throw new ArgumentNullException("user claims not found");

            var roles = await _context.UserRoles.Where(x => x.UserId == nameIdClaim.Value).Select(x => x.RoleId).ToListAsync();

            return new UserResponse()
            {
                Id = nameIdClaim.Value,
                Email = emailClaim.Value,
                Roles = roles,
            };
        }

        public async Task<UserDetailsResponse> GetCurrentUserDetails(ClaimsPrincipal? userClaims)
        {
            if (userClaims is null)
                throw new ArgumentNullException("user not found");

            if (userClaims.Identity is null)
                throw new ArgumentNullException("user identity not found");

            if (userClaims.Identity.IsAuthenticated == false)
                throw new UnauthorizedAccessException("user not authenticated");

            var emailClaim = userClaims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var nameIdClaim = userClaims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (emailClaim is null || nameIdClaim is null)
                throw new ArgumentNullException("user claims not found");

            var user = _context.Users.FirstOrDefault(x => x.Id == nameIdClaim.Value);

            if (user is null)
                throw new ArgumentNullException("user can not be null");

            var addresses = await _context.UserAddresses.Where(x => x.UserId == nameIdClaim.Value).Include(x => x.Address).ToListAsync();
            var homeAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Home)?.Address.ToResponse();
            var deliveryAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Delivery)?.Address.ToResponse();
            var invoiceAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Invoice)?.Address.ToResponse();

            var response = new UserDetailsResponse()
            {
                Id = nameIdClaim.Value,
                Email = emailClaim.Value,
                HomeAddress = homeAddress,
                DeliveryAddress = deliveryAddress,
            };

            user.SetDetailResponse(response);

            return response;
        }

        public async Task<UserResponse> CreateUser(UserRegisterRequest request)
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
                        CreatedOn = DateTime.Now,
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
                        CreatedOn = DateTime.Now,
                    };
                }

                var result = await _userManager.CreateAsync(userToCreate, request.UserAuthInfo.Password);

                if (!result.Succeeded)
                    throw new Exception();

                if (request.Address is not null)
                {
                    var createdAddress = _addressService.AddAddress(request.Address);

                    _addressService.AddUserAddress(userToCreate.Id, createdAddress, 1);
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return userToCreate.ToUserResponse();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
        }

        public async Task<UserResponse> UpdateUser(UserUpdateRequest request, string userId)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new Exception();

            user.Email = request.Email;
            user.UserName = request.Email;
            user.ModifiedOn = DateTime.Now;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new Exception();

            return user.ToUserResponse();
        }

        public async Task<bool> UpdatePassword(UserPasswordRequest request, ClaimsPrincipal? userClaims)
        {
            if (userClaims is null)
                throw new UnauthorizedAccessException("User not authenticated");

            var nameIdClaim = userClaims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (nameIdClaim is null)
                throw new ArgumentNullException("user id not found");

            if (request.Password != request.ConfirmPassword)
                return false;

            var user = await _userManager.FindByIdAsync(nameIdClaim.Value);

            if (user == null)
                return false;

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.Password);

            if (!result.Succeeded)
                return false;

            return true;
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

                    var applicationUser = await _userManager.Users.FirstAsync(x => x.Id == createdUser.Id);

                    var result = await _userManager.AddToRolesAsync(applicationUser, roles.GetRoles(role.Name));

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
