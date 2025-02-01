namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a quantity hop in the database. 
    /// </summary>
    public abstract class HopQuantity
    {
        /// <summary>
        /// The Entity id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The hop unit id
        /// </summary>
        public int HopUnitId { get; set; }

        /// <summary>
        /// The hop unit model representation
        /// </summary>
        public required HopUnit HopUnit { get; set; }

        /// <summary>
        /// The removal indicator
        /// </summary>
        public bool IsRemoved { get; set; }

        /// <summary>
        /// The info
        /// </summary>
        public string? Info { get; set; }
    }
}
