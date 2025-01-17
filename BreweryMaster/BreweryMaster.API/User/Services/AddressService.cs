﻿using BreweryMaster.API.Shared.Models.DB;
using BreweryMaster.API.User.Models;
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
