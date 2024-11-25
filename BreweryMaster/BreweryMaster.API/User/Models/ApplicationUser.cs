using Microsoft.AspNetCore.Identity;

namespace BreweryMaster.API.User.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool TestBool { get; set; }
    }
}
