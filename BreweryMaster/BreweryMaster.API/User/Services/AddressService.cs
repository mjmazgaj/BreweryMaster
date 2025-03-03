using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.DB;
using BreweryMaster.API.User.Models.Requests;
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
            var address = await _context.UserAddresses
                .Include(x => x.Address)
                .Include(x => x.AddressType)
                .FirstOrDefaultAsync(x => x.Address.Id == id);

            if (address is null)
                return null;

            return new AddressResponse()
            {
                Id = address.Address.Id,
                Street = address.Address.Street,
                HouseNumber = address.Address.HouseNumber,
                ApartamentNumber = address.Address.ApartamentNumber,
                City = address.Address.City,
                PostalCode = address.Address.PostalCode,
                Commune = address.Address.Commune,
                Region = address.Address.Region,
                Country = address.Address.Country,
                Type = address.AddressType.Name,
            };
        }

        public async Task<IEnumerable<EntityResponse>> GetAddressTypes()
        {
            return await _context.AddressTypes.Select(x=> new EntityResponse()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
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

        public async Task<AddressResponse?> CreateAddress(AddressTypeRequest request)
        {
            var addressToCreate = AddAddress(request);
            AddUserAddress(request.UserId, addressToCreate, request.TypeId);

            await _context.SaveChangesAsync();

            return await GetAddressById(addressToCreate.Id);
        }

        public async Task<AddressResponse?> CreateUserAddress(UserAddressRequest request)
        {
            var userAddresToCreate = new UserAddress
            {
                AddressId = request.AddressId,
                Address = null!,
                AddressType = null!,
                AddressTypeId = request.AddressTypeId,
                UserId = request.UserId,
                User = null!
            };

            _context.UserAddresses.Add(userAddresToCreate);
            await _context.SaveChangesAsync();

            return await GetAddressById(userAddresToCreate.AddressId);
        }
    }
}
