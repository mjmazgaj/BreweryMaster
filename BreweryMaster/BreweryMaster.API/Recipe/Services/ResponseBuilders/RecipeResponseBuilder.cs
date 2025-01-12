using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Models.DB;

namespace BreweryMaster.API.Recipe.Services.ResponseBuilders
{
    public class RecipeResponseBuilder
    {
        private readonly RecipeDetailsResponse _recipeResponse;

        public RecipeResponseBuilder(string name)
        {
            _recipeResponse = new RecipeDetailsResponse() { Name = name };
        }

        public RecipeResponseBuilder SetFieldsWithRecipe(Models.DB.Recipe recipe)
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
        public RecipeResponseBuilder SetFermentingIngredients(IEnumerable<RecipeFermentingIngredient> recipeFermentingIngredients, Dictionary<int, string> dbIngredientTypes)
        {
            _recipeResponse.FermentingIngredientUnits = recipeFermentingIngredients.Select(x =>
            {
                var fermentingIngredient = x.FermentingIngredientUnit.FermentingIngredient;
                return new RecipeFermentingIngredientResponse()
                {
                    Id = x.Id,
                    TypeId = fermentingIngredient.TypeId,
                    TypeName = dbIngredientTypes.TryGetValue(fermentingIngredient.TypeId, out var typeName) ? typeName : "",
                    Name = fermentingIngredient.Name,
                    Percentage = fermentingIngredient.Percentage,
                    Extraction = fermentingIngredient.Extraction,
                    EBC = fermentingIngredient.EBC,
                    Quantity = x.Quantity,
                    Unit = x.FermentingIngredientUnit.Unit.Name,
                    Info = fermentingIngredient.Info
                };
            }
            );

            return this;
        }
        public RecipeDetailsResponse Build()
        {
            return _recipeResponse;
        }

    }
}
