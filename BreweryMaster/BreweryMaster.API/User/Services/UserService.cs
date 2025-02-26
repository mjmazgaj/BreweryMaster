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

        public async Task<IEnumerable<UserResponse>> GetUsers(UserFilterRequest? request = null)
        {
            var response = new List<UserResponse>();
            var companyUsers = new List<CompanyUser>();
            var individualUsers = new List<IndividualUser>();

            if (request is null)
            {
                companyUsers = await _context.CompanyUsers.Include(x => x.UserAddresses).ToListAsync();
                individualUsers = await _context.IndividualUsers.Include(x => x.UserAddresses).ToListAsync();
            }
            else
            {
                companyUsers = await _context.CompanyUsers
                                    .Include(x => x.UserAddresses)
                                    .Where(x => request.Email == null || x.Email == null || x.Email.Contains(request.Email))
                                    .Where(x => request.CreatedAfter == null || x.CreatedOn >= request.CreatedAfter)
                                    .Where(x => request.CreatedBefore == null || x.CreatedOn <= request.CreatedBefore)
                                    .Where(x => request.IsCompany ?? true)
                                    .ToListAsync();


                individualUsers = await _context.IndividualUsers
                                    .Include(x => x.UserAddresses)
                                    .Where(x => request.Email == null || x.Email == null || x.Email.Contains(request.Email))
                                    .Where(x => request.CreatedAfter == null || x.CreatedOn >= request.CreatedAfter)
                                    .Where(x => request.CreatedBefore == null || x.CreatedOn <= request.CreatedBefore)
                                    .Where(x => !request.IsCompany ?? true)
                                    .ToListAsync();

                if (request.RoleId != null)
                {
                    companyUsers = companyUsers.Where(x => _userManager.GetRolesAsync(x).Result.Contains(request.RoleId)).ToList();
                    individualUsers = individualUsers.Where(x => _userManager.GetRolesAsync(x).Result.Contains(request.RoleId)).ToList();
                }
            }



            response.AddRange(companyUsers.Select(x => new UserResponse()
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.CompanyName,
                Roles = _userManager.GetRolesAsync(x).Result,
                CreatedOn = DateOnly.FromDateTime(x.CreatedOn),
                IsCompany = true
            }));

            response.AddRange(individualUsers.Select(x => new UserResponse()
            {
                Id = x.Id,
                Email = x.Email,
                Name = $"{x.Surname} {x.Forename}",
                Roles = _userManager.GetRolesAsync(x).Result,
                CreatedOn = DateOnly.FromDateTime(x.CreatedOn),
                IsCompany = false
            }));


            return response;
        }

        public async Task<IEnumerable<EntityStringIdResponse>> GetUserDropDownList()
        {
            var users = await GetUsers();

            return users.Select(x => new EntityStringIdResponse()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public async Task<IEnumerable<EntityStringIdResponse>> GetRolesDropDownList()
        {
            var users = await _context.Roles.ToListAsync();

            return users.Select(x => new EntityStringIdResponse()
            {
                Id = x.Id,
                Name = x.Name ?? string.Empty
            });
        }

        public async Task<UserDetailsResponse?> GetUserById(string id)
        {

            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
                return null;

            var addresses = await _context.UserAddresses.Where(x => x.UserId == id).Include(x => x.Address).ToListAsync();
            var homeAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Home)?.Address.ToResponse();
            var deliveryAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Delivery)?.Address.ToResponse();
            var invoiceAddress = addresses.FirstOrDefault(x => x.AddressTypeId == (int)AddressType.Invoice)?.Address.ToResponse();

            var response = new UserDetailsResponse()
            {
                Id = id,
                Email = user.Email ?? string.Empty,
                HomeAddress = homeAddress,
                DeliveryAddress = deliveryAddress,
                Roles = _userManager.GetRolesAsync(user).Result
            };

            user.SetDetailResponse(response);

            return response;
        }

        public async Task<UserResponse> GetCurrentUser(ClaimsPrincipal? user)
        {
            if (user is null)
                throw new UnauthorizedAccessException("User claims not found");

            var emailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var nameIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (emailClaim is null || nameIdClaim is null)
                throw new ArgumentNullException("User claims not found");

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
                throw new UnauthorizedAccessException("User claims not found");

            var emailClaim = userClaims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var nameIdClaim = userClaims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (emailClaim is null || nameIdClaim is null)
                throw new ArgumentNullException("user claims not found");

            var user = _context.Users.FirstOrDefault(x => x.Id == nameIdClaim.Value);

            if (user is null)
                throw new ArgumentNullException("user not found");

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

        public async Task<UserResponse?> CreateUser(UserRegisterRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                ApplicationUser userToCreate = null!;

                if (request.IsCompany)
                {
                    if (request.CompanyUserInfo is null)
                        return null;

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
                        return null;

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
                    return null;

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

        public async Task<UserResponse?> UpdateUser(UserUpdateRequest request, string userId)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                throw new ArgumentNullException("User not found");

            user.Email = request.Email;
            user.UserName = request.Email;
            user.ModifiedOn = DateTime.Now;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return null;

            return user.ToUserResponse();
        }

        public async Task<bool> UpdatePassword(UserPasswordRequest request, ClaimsPrincipal? userClaims)
        {
            if (userClaims is null)
                throw new UnauthorizedAccessException("User claims not found");

            var nameIdClaim = userClaims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (nameIdClaim is null)
                throw new UnauthorizedAccessException("User name not found");

            var user = await _userManager.FindByIdAsync(nameIdClaim.Value);

            if (user == null)
                throw new ArgumentNullException("User not found");

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.Password);

            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task<bool> UpdateUserRoles(UserRolesUpdateRequest request)
        {
            if (request.RolesId == null)
                throw new ArgumentNullException("Roles list cant be empty");

            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
                throw new ArgumentNullException("User not found");

            var currentRoles = await _userManager.GetRolesAsync(user);
            var rolesToAdd = request.RolesId.Except(currentRoles).ToList();
            var rolesToRemove = currentRoles.Except(request.RolesId).ToList();

            if (rolesToAdd.Any())
            {
                var addResult = await _userManager.AddToRolesAsync(user, rolesToAdd);
                if (!addResult.Succeeded)
                    return false;
            }

            if (rolesToRemove.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                if (!removeResult.Succeeded)
                    return false;
            }

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

                var createdUser = await CreateUser(userRequest);

                if (createdUser == null)
                    throw new ArgumentNullException("User not created");

                var applicationUser = await _userManager.Users.FirstAsync(x => x.Id == createdUser.Id);

                var result = await _userManager.AddToRolesAsync(applicationUser, roles.GetRoles(role.Name));

                if (!result.Succeeded)
                    return false;
            }

            return true;
        }

    }
}
