namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a stored fermenting ingredient in the database. 
    /// </summary>
    public class FermentingIngredientStored : FermentingIngredientQuantity
    {
        /// <summary>
        /// The stored quantity
        /// </summary>
        public float StoredQuantity { get; set; }
    }
}
