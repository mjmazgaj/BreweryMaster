using BreweryMaster.API.Info.Models;

namespace BreweryMaster.API.Recipe.Models.DB
{
    public class RecipeFermentingIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        public int FermentingIngredientUnitId { get; set; }
        public required FermentingIngredientUnit FermentingIngredientUnit { get; set; }
        public float Quantity { get; set; }
        public string? Info { get; set; }
    }
}