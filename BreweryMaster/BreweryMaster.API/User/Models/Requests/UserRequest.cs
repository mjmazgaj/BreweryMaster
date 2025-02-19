namespace BreweryMaster.API.User.Models
{
    public class UserRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
