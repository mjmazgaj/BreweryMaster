namespace BreweryMaster.API.User.Models.Users
{
    public class UserResponse
    {
        public required string Id { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedOn { get; set; }
        public bool IsCompany { get; set; }
        public IEnumerable<string>? Roles { get; set; }
    }
}
