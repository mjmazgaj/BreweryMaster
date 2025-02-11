namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a quantity fermenting ingredient in the database. 
    /// </summary>
    public abstract class FermentingIngredientQuantity
    {
        /// <summary>
        /// The Entity id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The fermenting ingredient unit id
        /// </summary>
        public int FermentingIngredientUnitId { get; set; }

        /// <summary>
        /// The fermenting ingredient unit model representation
        /// </summary>
        public FermentingIngredientUnit FermentingIngredientUnit { get; set; } = null!;

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
