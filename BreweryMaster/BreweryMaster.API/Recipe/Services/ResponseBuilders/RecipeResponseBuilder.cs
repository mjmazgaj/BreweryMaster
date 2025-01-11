using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Models.DB;

namespace BreweryMaster.API.Recipe.Services.ResponseBuilders
{
    public class RecipeResponseBuilder
    {
        private readonly RecipeResponse _recipeResponse;

        public RecipeResponseBuilder(string name)
        {
            _recipeResponse = new RecipeResponse() { Name = name };
        }

        public RecipeResponseBuilder SetFieldsWithResponse(Models.DB.Recipe recipe)
        {
            _recipeResponse.Id = recipe.Id;
            _recipeResponse.BLGScale = recipe.BLGScale;
            _recipeResponse.IBUScale = recipe.IBUScale;
            _recipeResponse.ABVScale = recipe.ABVScale;
            _recipeResponse.SRMScale = recipe.SRMScale;
            _recipeResponse.TypeId = recipe.Type?.Id;
            _recipeResponse.TypeName = recipe.Type?.Name;
            _recipeResponse.StyleId = recipe.Style?.Id;
            _recipeResponse.StyleName = recipe.Style?.Name;
            _recipeResponse.ExpectedBeerVolume = recipe.ExpectedBeerVolume;
            _recipeResponse.BoilTime = recipe.BoilTime;
            _recipeResponse.EvaporationRate = recipe.EvaporationRate;
            _recipeResponse.WortVolume = recipe.WortVolume;
            _recipeResponse.BoilLoss = recipe.BoilLoss;
            _recipeResponse.PreBoilGravity = recipe.PreBoilGravity;
            _recipeResponse.FermentationLoss = recipe.FermentationLoss;
            _recipeResponse.DryHopLoss = recipe.DryHopLoss;
            _recipeResponse.MashEfficiency = recipe.MashEfficiency;
            _recipeResponse.WaterToGrainRatio = recipe.WaterToGrainRatio;
            _recipeResponse.MashWaterVolume = recipe.MashWaterVolume;
            _recipeResponse.TotalMashVolume = recipe.TotalMashVolume;

            return this;
        }
        public RecipeResponseBuilder SetFermentingIngredients(IEnumerable<RecipeFermentingIngredient> recipeFermentingIngredients, int recipeId)
        {
            _recipeResponse.FermentingIngredients = recipeFermentingIngredients
                    .Where(y => y.RecipeId == recipeId)
                    .Select(y => y.FermentingIngredient);
            return this;
        }
        public RecipeResponse Build()
        {
            return _recipeResponse;
        }

    }
}
