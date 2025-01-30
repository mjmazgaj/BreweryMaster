namespace BreweryMaster.API.Info.Models
{
    /// <summary>
    /// Represents a ordered fermenting ingredient in the database. 
    /// </summary>
    public class FermentingIngredientOrdered : FermentingIngredientQuantity
    {
        /// <summary>
        /// The ordered quantity
        /// </summary>
        public float OrderedQuantity { get; set; }

        /// <summary>
        /// The ordered date
        /// </summary>
        public DateTime OrderedDate { get; set; }

        /// <summary>
        /// The expected date
        /// </summary>
        public DateTime? ExpectedDate { get; set; }
    }
}
