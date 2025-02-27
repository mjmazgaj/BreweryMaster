using Microsoft.EntityFrameworkCore;

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
        public int OrderedQuantity { get; set; }

        /// <summary>
        /// The ordered date
        /// </summary>
        public DateTime OrderedDate { get; set; }

        /// <summary>
        /// The expected date
        /// </summary>
        public DateTime? ExpectedDate { get; set; }

        /// <summary>
        /// The completion indicator
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
