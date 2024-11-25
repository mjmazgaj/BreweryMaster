namespace BreweryMaster.API.User.Models
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool TestBool { get; set; }
    }
}
