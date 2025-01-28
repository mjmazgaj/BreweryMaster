using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a item price in the database.
    /// </summary>
    public abstract class ItemPrice
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

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
