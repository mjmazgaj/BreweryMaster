using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Models.DB;
using BreweryMaster.API.Recipe.Models.Responses;

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

        public RecipeResponseBuilder SetFermentingIngredients(IEnumerable<RecipeFermentingIngredient> recipeFermentingIngredients)
        {
            _recipeResponse.FermentingIngredients = recipeFermentingIngredients.Select(x =>
            {
                var fermentingIngredient = x.FermentingIngredientUnit.FermentingIngredient;
                return new RecipeFermentingIngredientResponse()
                {
                    Id = x.FermentingIngredientUnitId,
                    TypeId = fermentingIngredient.TypeId,
                    TypeName = fermentingIngredient.Type.Name,
                    Name = fermentingIngredient.Name,
                    Percentage = fermentingIngredient.Percentage,
                    Extraction = fermentingIngredient.Extraction,
                    EBC = fermentingIngredient.EBC,
                    Quantity = (decimal)x.Quantity,
                    Unit = x.FermentingIngredientUnit.Unit.Name,
                    Info = x.Info
                };
            }
            );

            return this;
        }

        public RecipeResponseBuilder SetHops(IEnumerable<RecipeHop> recipeHops)
        {
            _recipeResponse.Hops = recipeHops.Select(x =>
            {
                var hop = x.HopUnit.Hop;
                return new RecipeHopResponse()
                {
                    Id = x.HopUnitId,
                    Name = hop.Name,
                    AlphaAcids = hop.AlphaAcids,
                    Quantity = (decimal)x.Quantity,
                    Unit = x.HopUnit.Unit.Name,
                    Info = x.Info
                };
            }
            );

            return this;
        }

        public RecipeResponseBuilder SetYeast(IEnumerable<RecipeYeast> recipeYeast)
        {
            _recipeResponse.Yeast = recipeYeast.Select(x =>
            {
                var yeast = x.YeastUnit.Yeast;
                return new RecipeYeastResponse()
                {
                    Id = x.YeastUnitId,
                    Name = yeast.Name,
                    FormId = yeast.FormId,
                    FormName = yeast.Form.Name,
                    Producer = yeast.Producer,
                    TypeId = yeast.TypeId,
                    TypeName = yeast.Type.Name,
                    Quantity = (decimal)x.Quantity,
                    Unit = x.YeastUnit.Unit.Name,
                    Info = x.Info
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
