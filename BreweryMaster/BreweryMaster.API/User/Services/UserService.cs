using Azure.Core;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.User.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
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

        public async Task<AddressResponse?> GetAddressById(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);

            AddressResponse addressResponse = null!;

            if (address is not null)
            {
                addressResponse = new AddressResponse()
                {
                    Id = address.Id,
                    Street = address.Street,
                    HouseNumber = address.HouseNumber,
                    ApartamentNumber = address.ApartamentNumber,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Commune = address.Commune,
                    Region = address.Region,
                    Country = address.Country,
                };
            };

            return addressResponse;
        }

        public async Task<ApplicationUser> CreateUser(UserRegisterRequest request)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var userToCreate = new ApplicationUser
                {
                    UserName = request.UserAuthInfo.Email,
                    Email = request.UserAuthInfo.Email,
                };

                var result = await _userManager.CreateAsync(userToCreate, request.UserAuthInfo.Password);

                if (!result.Succeeded)
                    throw new Exception();

                if (request.Address is not null)
                    AddAddress(request.Address, userToCreate.Id);

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

        public Address AddAddress(AddressRequest request, string userId)
        {
            var addressToCreate = new Address
            {
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                ApartamentNumber = request.ApartamentNumber,
                City = request.City,
                PostalCode = request.PostalCode,
                Commune = request.Commune,
                Region = request.Region,
                Country = request.Country,
                UserId = userId,
                User = null!,
            };

            _context.Addresses.Add(addressToCreate);

            return addressToCreate;
        }

        public async Task<Address> CreateAddress(AddressRequest request, string userId)
        {
            var addressToCreate = AddAddress(request, userId);
            await _context.SaveChangesAsync();
            return addressToCreate;
        }
    }
}
