using BreweryMaster.API.User.Models;

public interface IAddressService
{
    Task<IEnumerable<Address>> GetAddressesAsync();
    Task<Address> GetAddressByIdAsync(int id);
    Task<Address> CreateAddressAsync(Address address);
    Task<bool> EditAddressAsync(int id, Address address);
    Task<bool> DeleteAddressByIdAsync(int id);
}
