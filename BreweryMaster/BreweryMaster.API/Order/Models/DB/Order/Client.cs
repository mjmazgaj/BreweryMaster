using BreweryMaster.API.User.Models.DB;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BreweryMaster.API.OrderModule.Models
{
    /// <summary>
    /// Represents a client in the database.
    /// </summary>
    public class Client
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
        /// The address of the client. 
        /// </summary>
        [JsonIgnore]
        public ICollection<ClientAddress>? ClientAddresses { get; set; }

        /// <summary>
        /// The list of orders related to the client
        /// </summary>
        public ICollection<Order>? Orders { get; set; }

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
