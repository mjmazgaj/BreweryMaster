namespace BreweryMaster.API.User.Models.Users
{
    public class UserRegisterRequest
    {
        public required UserRequest UserAuthInfo { get; set; }
        public AddressRequest? Address { get; set; }
    }
}
