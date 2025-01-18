using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Models;

namespace BreweryMaster.API.User.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>?> GetUsers();
        Task<UserResponse?> GetUserById(string id);
        Task<AddressResponse?> GetAddressById(int id);
        Task<ApplicationUser> CreateUser(UserRegisterRequest request);
        Address AddAddress(AddressRequest request, string userId);
        Task<Address> CreateAddress(AddressRequest request, string userId);
    }
}
