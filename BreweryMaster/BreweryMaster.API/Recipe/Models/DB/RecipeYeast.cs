using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Recipe.Models.DB
{
    /// <summary>
    /// Represents a yeast addition in a recipe.
    /// </summary>
    public class RecipeYeast
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
        /// The yeast unit ID.
        /// </summary>
        public int YeastUnitId { get; set; }

        /// <summary>
        /// The yeast unit entity reference.
        /// </summary>
        public required YeastUnit YeastUnit { get; set; }

        /// <summary>
        /// The quantity of yeast used in the recipe.
        /// </summary>
        [Precision(5, 2)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Additional information about the yeast usage.
        /// </summary>
        public string? Info { get; set; }
    }
}
