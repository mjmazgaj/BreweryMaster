using BreweryMaster.API.User.Models;
using BreweryMaster.API.UserModule.Models;

namespace BreweryMaster.API.User.Helpers
{
    public static class AddressMapper
    {
        public static AddressResponse ToResponse(this Address address)
        {
            return new AddressResponse
            {
                Id = address.Id,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                ApartamentNumber = address.ApartamentNumber,
                PostalCode = address.PostalCode,
                City = address.City,
                Commune = address.Commune,
                Region = address.Region,
                Country = address.Country,
            };
        }
    }
}
