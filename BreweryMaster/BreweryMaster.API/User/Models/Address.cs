namespace BreweryMaster.API.User.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ApartamentNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Commune { get; set; }
    }
}
