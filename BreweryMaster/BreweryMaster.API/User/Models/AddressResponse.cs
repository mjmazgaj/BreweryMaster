namespace BreweryMaster.API.User.Models
{
    public class AddressResponse
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
    }
}
