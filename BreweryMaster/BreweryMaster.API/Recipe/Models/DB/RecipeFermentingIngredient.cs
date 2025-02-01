using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Recipe.Models.DB
{
    /// <summary>
    /// Represents a fermenting ingredient used in a recipe.
    /// </summary>
    public class RecipeFermentingIngredient
    {
        /// <summary>
        /// The associated recipe ID.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// The recipe entity reference.
        /// </summary>
        public required Recipe Recipe { get; set; }

        /// <summary>
        /// The fermenting ingredient unit ID.
        /// </summary>
        public int FermentingIngredientUnitId { get; set; }

        /// <summary>
        /// The fermenting ingredient unit entity reference.
        /// </summary>
        public required FermentingIngredientUnit FermentingIngredientUnit { get; set; }

        /// <summary>
        /// The quantity of the ingredient used in the recipe.
        /// </summary>
        [Precision(5, 2)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Additional information about the ingredient usage.
        /// </summary>
        public string? Info { get; set; }
    }
}