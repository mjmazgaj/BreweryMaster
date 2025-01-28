using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents an prospect client in the database.
    /// </summary>
    public class ProspectClient
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        [MaxLength(50)]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        [MaxLength(255)]
        public required string Email { get; set; }

        /// <summary>
        /// The list of prospect orders related to the client
        /// </summary>
        public ICollection<ProspectOrder>? Orders { get; set; }

        /// <summary>
        /// The date of creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// The removal indicator
        /// </summary>
        public bool IsRemoved { get; set; }
    }
}
