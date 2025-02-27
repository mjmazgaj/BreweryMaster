using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.Users
{
    public class UserRegisterRequest
    {
        [Required]
        public required UserRequest UserAuthInfo { get; set; }

        public AddressRequest? Address { get; set; }

        [Required]
        public bool IsCompany { get;}

        public IndividualUserRequest? IndividualUserInfo { get; set; }

        public CompanyUserRequest? CompanyUserInfo{ get; set; }
    }
}
