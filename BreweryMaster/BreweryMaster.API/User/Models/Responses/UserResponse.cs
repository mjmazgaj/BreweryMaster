namespace BreweryMaster.API.User.Models.Users
{
    public class UserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly CreatedOn { get; set; }
        public bool IsCompany { get; set; }
        public IEnumerable<string>? Roles { get; set; }
    }
}
