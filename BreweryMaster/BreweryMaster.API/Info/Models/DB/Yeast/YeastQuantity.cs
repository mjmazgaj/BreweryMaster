namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a quantity yeast in the database. 
    /// </summary>
    public abstract class YeastQuantity
    {
        /// <summary>
        /// The Entity id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The yeast unit id
        /// </summary>
        public int YeastUnitId { get; set; }

        /// <summary>
        /// The yeast unit model representation
        /// </summary>
        public required YeastUnit YeastUnit { get; set; }

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
