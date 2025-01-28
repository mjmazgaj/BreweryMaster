using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.UserModule.Models;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.DB
{
    /// <summary>
    /// Represents an individual user stored in the database.
    /// </summary>
    public class IndividualUser : ApplicationUser
    {
        /// <summary>
        /// First name of the user.
        /// </summary>
        [MaxLength(255)]
        public required string Forename { get; set; }

        /// <summary>
        /// Last name of the user.
        /// </summary>
        [MaxLength(255)]
        public required string Surname { get; set; }
    }
}
