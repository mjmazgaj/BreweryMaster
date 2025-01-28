namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a beer price per 100 liters stored in the database.
    /// </summary>
    public class BeerPrice : ItemPrice
    {
        /// <summary>
        /// The beer style id
        /// </summary>
        public int BeerStyleId { get; set; }

        /// <summary>
        /// The beer style model representation
        /// </summary>
        public required BeerStyleEntity BeerStyle { get; set; }
    }
}
