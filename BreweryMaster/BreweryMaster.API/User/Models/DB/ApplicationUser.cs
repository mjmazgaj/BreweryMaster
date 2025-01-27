using Microsoft.AspNetCore.Identity;

namespace BreweryMaster.API.User.Models.Users.DB
{
    /// <summary>
    /// Represents an individual user stored in the database.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// The removal indicator
        /// </summary>
        public bool IsRemoved { get; set; } = false;
    }
}
