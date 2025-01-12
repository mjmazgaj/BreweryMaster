using BreweryMaster.API.Info.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryMaster.API.Recipe.Models.DB
{
    public class RecipeFermentingIngredient
    {
        public int Id { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        [ForeignKey("FermentingIngredientUnit")]
        public int FermentingIngredientUnitId { get; set; }
        public required FermentingIngredientUnit FermentingIngredientUnit { get; set; }
        public float Quantity { get; set; }
    }
}