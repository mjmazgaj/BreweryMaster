namespace BreweryMaster.API.Models.User
{
    public class Client
    {
        public int ID { get; set; }
        public string Forename { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public int? NIP { get; set; }
        public int? AddressId { get; set; }
        public int? DeliveryAddressId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
