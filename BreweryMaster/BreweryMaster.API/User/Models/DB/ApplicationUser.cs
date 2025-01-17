using BreweryMaster.API.UserModule.Models;
using Microsoft.AspNetCore.Identity;

namespace BreweryMaster.API.User.Models.Users.DB
{
    public class ApplicationUser : IdentityUser
    {
        public Address? Address { get; set; }
        public bool IsRemoved { get; set; } = false;
    }
}
