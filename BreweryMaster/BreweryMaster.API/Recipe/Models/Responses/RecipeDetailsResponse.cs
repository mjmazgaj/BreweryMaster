using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Recipe.Models.Responses;

namespace BreweryMaster.API.Recipe.Models
{
    public class RecipeDetailsResponse
    {
        public required RecipeResponse GeneralInfo { get; set; }
        public required RecipeBatchResponse BatchInfo { get; set; }
        public required RecipeMashResponse MashInfo { get; set; }
        public string? Info { get; set; }
        public IEnumerable<RecipeFermentingIngredientResponse>? FermentingIngredients { get; set; }
        public IEnumerable<RecipeHopResponse>? Hops{ get; set; }
        public IEnumerable<RecipeYeastResponse>? Yeast { get; set; }
    }
}
