using BreweryMaster.API.User.Models.Users.DB;

namespace BreweryMaster.API.UserModule.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public required string HouseNumber { get; set; }
        public string? ApartamentNumber { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public required string Commune { get; set; }
        public required string Region { get; set; }
        public required string Country { get; set; }

        public required string UserId { get; set; }
        public required ApplicationUser User { get; set; }
    }
}
