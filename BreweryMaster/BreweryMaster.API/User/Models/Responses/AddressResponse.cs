namespace BreweryMaster.API.User.Models
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string HouseNumber { get; set; } = string.Empty;
        public string? ApartamentNumber { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Commune { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
