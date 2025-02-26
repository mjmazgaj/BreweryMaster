namespace BreweryMaster.API.User.Models.Responses
{
    public class UserDetailsResponse
    {
        public string Id { get; set; } = string.Empty;
        public CompanyUserResponse? CompanyUser { get; set; }
        public IndividualUserResponse? IndividualUser { get; set; }
        public AddressResponse? HomeAddress { get; set; }
        public AddressResponse? DeliveryAddress { get; set; }
        public string Email { get; set; } = string.Empty;
        public IEnumerable<string>? Roles { get; set; }
        public bool IsCompany { get; set; }
    }
}
