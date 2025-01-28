using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a container price in the database.
    /// </summary>
    public class ContainerPrice
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The container id
        /// </summary>
        public int ContainerId { get; set; }

        /// <summary>
        /// The container model representation
        /// </summary>
        public required Container Container { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        [Precision(18, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// The date of creation
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
