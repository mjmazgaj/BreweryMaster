namespace BreweryMaster.API.UserModule.Models
{
    public class RegisterUserRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public bool TestBool { get; set; }
    }
}
