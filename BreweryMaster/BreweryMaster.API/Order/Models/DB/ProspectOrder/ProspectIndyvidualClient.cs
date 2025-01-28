using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents an prospect individual client in the database.
    /// </summary>
    public class ProspectIndyvidualClient : ProspectClient
    {
        /// <summary>
        /// The forname
        /// </summary>
        [MaxLength(255)]
        public required string Forename { get; set; }

        /// <summary>
        /// The surname
        /// </summary>
        [MaxLength(255)]
        public required string Surname { get; set; }
    }
}
