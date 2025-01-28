using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a beer price in the database.
    /// </summary>
    public class BeerPrice
    {
        /// <summary>
        /// Entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The beer style id
        /// </summary>
        public int BeerStyleId { get; set; }

        /// <summary>
        /// The beer style model representation
        /// </summary>
        public required BeerStyleEntity BeerStyle { get; set; }

        /// <summary>
        /// The price per 100 litters
        /// </summary>
        [Precision(18, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// The date of creation
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
