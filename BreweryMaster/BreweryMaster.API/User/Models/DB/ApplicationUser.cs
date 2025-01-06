using Microsoft.AspNetCore.Identity;

namespace BreweryMaster.API.User.Models.DB
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsRemoved { get; set; } = false;
    }
}
