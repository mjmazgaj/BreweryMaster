using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.UserModule.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.User.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext _context;
        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AddressResponse?> GetAddressById(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);

            if (address is null)
                return null;

            return new AddressResponse()
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
        }

        public Address AddAddress(AddressRequest request)
        {
            if (request is null)
                throw new ArgumentNullException($"{nameof(request)} can not be null.");

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
            };

            _context.Addresses.Add(addressToCreate);

            return addressToCreate;
        }

        public UserAddress AddUserAddress(string userId, Address address, int addressType)
        {
            if (address is null)
                throw new ArgumentNullException($"{nameof(address)} can not be null.");

            if (userId is null)
                throw new ArgumentNullException($"{nameof(userId)} can not be null.");

            if (addressType < 0)
                throw new ArgumentException($"{nameof(addressType)} show be greater then 0.");

            var userAddress = new UserAddress
            {
                UserId = userId,
                User = null!,
                Address = address,
                AddressTypeId = addressType,
                AddressType = null!,
            };

            _context.Add(userAddress);

            return userAddress;
        }
    }
}
