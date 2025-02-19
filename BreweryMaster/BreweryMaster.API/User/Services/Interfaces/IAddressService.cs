using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Models;

namespace BreweryMaster.API.User.Services
{
    public interface IAddressService
    {
        Task<AddressResponse?> GetAddressById(int id);
        Address AddAddress(AddressRequest request);
        UserAddress AddUserAddress(string userId, Address address, int addressType);
    }
}
