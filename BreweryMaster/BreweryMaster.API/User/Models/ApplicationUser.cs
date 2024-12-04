using Microsoft.AspNetCore.Identity;

namespace BreweryMaster.API.UserModule.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool TestBool { get; set; }
    }
}
