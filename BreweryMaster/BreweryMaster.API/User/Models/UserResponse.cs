namespace BreweryMaster.API.User.Models.Users
{
    public class UserResponse
    {
        public required string Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public bool IsCompany { get; set; }
    }
}
