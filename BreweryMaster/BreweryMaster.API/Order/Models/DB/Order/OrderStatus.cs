using System.ComponentModel.DataAnnotations;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a order status in the database.
    /// </summary>
    public class OrderStatus
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        [MaxLength(256)]
        public required string Name { get; set; }
    }
}
