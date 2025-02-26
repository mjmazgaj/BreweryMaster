using BreweryMaster.API.User.Models.Users.DB;
using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.User.Models.DB
{
    /// <summary>
    /// Represents an company user stored in the database.
    /// </summary>
    public class CompanyUser : ApplicationUser
    {
        /// <summary>
        /// The name of the company
        /// </summary>
        [MaxLength(256)]
        public required string CompanyName { get; set; }

        /// <summary>
        /// The tax identifier of the company
        /// </summary>
        [MaxLength(256)]
        public required string Nip { get; set; }
    }
}
