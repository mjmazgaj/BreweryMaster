using BreweryMaster.API.Shared.Models.DB;
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
        private readonly ApplicationDbContext _context;
        private readonly IAddressService _addressService;

        public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IAddressService addressService)
        {
            _userManager = userManager;
            _context = context;
            _addressService = addressService;
        }

        public async Task<IEnumerable<UserResponse>?> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Select(x => new UserResponse()
            {
                Id = x.Id,
                Email = x.Email
            });
        }

        public async Task<UserResponse?> GetUserById(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

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

        public UserResponse GetCurrentUser(ClaimsPrincipal? user)
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

            return new UserResponse()
            {
                Id = nameIdClaim.Value,
                Email = emailClaim.Value
            };
        }

        public async Task<ApplicationUser> CreateUser(UserRegisterRequest request)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                ApplicationUser userToCreate = null!;

                if(request.IsCompany)
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
    }
}
