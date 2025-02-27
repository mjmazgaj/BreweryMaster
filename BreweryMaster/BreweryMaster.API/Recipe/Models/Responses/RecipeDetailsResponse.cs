using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Recipe.Models.Responses;

namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeDetailsResponse
    {
        public RecipeResponse GeneralInfo { get; set; } = null!;
        public RecipeBatchResponse BatchInfo { get; set; } = null!;
        public RecipeMashResponse MashInfo { get; set; } = null!;
        public string? Info { get; set; }
        public IEnumerable<RecipeFermentingIngredientResponse>? FermentingIngredients { get; set; }
        public IEnumerable<RecipeHopResponse>? Hops{ get; set; }
        public IEnumerable<RecipeYeastResponse>? Yeast { get; set; }
    }
}
