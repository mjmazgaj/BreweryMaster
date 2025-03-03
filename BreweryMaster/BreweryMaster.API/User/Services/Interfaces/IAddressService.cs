using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.UserModule.Models;

namespace BreweryMaster.API.User.Services
{
    public interface IAddressService
    {
        Task<AddressResponse?> GetAddressById(int id);
        Task<IEnumerable<EntityResponse>> GetAddressTypes();
        Address AddAddress(AddressRequest request);
        UserAddress AddUserAddress(string userId, Address address, int addressType);
        Task<AddressResponse?> CreateAddress(AddressTypeRequest request);
        Task<AddressResponse?> CreateUserAddress(UserAddressRequest request);
    }
}
