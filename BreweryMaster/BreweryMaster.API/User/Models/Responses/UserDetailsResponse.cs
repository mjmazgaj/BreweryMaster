namespace BreweryMaster.API.User.Models.Responses
{
    public class UserDetailsResponse
    {
        public required string Id { get; set; }
        public CompanyUserResponse? CompanyUser { get; set; }
        public IndividualUserResponse? IndividualUser { get; set; }
        public required AddressResponse HomeAddress { get; set; } = null!;
        public AddressResponse? DeliveryAddress { get; set; }
        public required string Email { get; set; }
        public IEnumerable<string>? Roles { get; set; }
        public bool IsCompany { get; set; }
    }
}
