namespace BreweryMaster.API.User.Models.Users
{
    public class UserRegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
