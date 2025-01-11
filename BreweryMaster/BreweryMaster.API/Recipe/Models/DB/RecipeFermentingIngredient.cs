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
        [ForeignKey("FermentingIngredient")]
        public int FermentingIngredientId { get; set; }
        public required FermentingIngredient FermentingIngredient { get; set; }
    }
}