using BreweryMaster.API.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Services
{
    public class AddressService
    {
        private readonly UserContext _context;

        public AddressService(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            var addressToCreate = new Address()
            {
                City = address.City,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                ApartamentNumber = address.ApartamentNumber,
                PostalCode = address.PostalCode,
                Country = address.Country,
                Region = address.Region,
                Commune = address.Commune
            };

            _context.Addresses.Add(addressToCreate);
            await _context.SaveChangesAsync();

            return addressToCreate;
        }

        public async Task<bool> EditAddressAsync(int id, Address address)
        {
            if (id != address.ID)
                return false;

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<bool> DeleteAddressByIdAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.ID == id);

            if (address == null)
                return false;

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(x => x.ID == id);
        }
    }
}
