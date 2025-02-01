using BreweryMaster.API.Info.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Recipe.Models.DB
{
    /// <summary>
    /// Represents a hop addition in a recipe.
    /// </summary>
    public class RecipeHop
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
        /// The hop unit ID.
        /// </summary>
        public int HopUnitId { get; set; }

        /// <summary>
        /// The hop unit entity reference.
        /// </summary>
        public required HopUnit HopUnit { get; set; }

        /// <summary>
        /// The quantity of hops used in the recipe.
        /// </summary>
        [Precision(5, 2)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Additional information about the hop usage.
        /// </summary>
        public string? Info { get; set; }
    }
}
