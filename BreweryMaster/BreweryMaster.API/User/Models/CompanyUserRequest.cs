namespace BreweryMaster.API.User.Models
{
    public class CompanyUserRequest
    {
        public required string CompanyName { get; set; }
        public required string Nip { get; set; }
        public AddressRequest? InvoiceAddress { get; set; }
    }
}
