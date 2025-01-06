namespace BreweryMaster.API.User.Models.Users
{
    public class UserUpdateRequest
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
