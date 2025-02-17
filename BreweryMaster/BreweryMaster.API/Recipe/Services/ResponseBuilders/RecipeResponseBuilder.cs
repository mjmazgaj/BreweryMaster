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
            _recipeResponse = new RecipeDetailsResponse()
            {
                GeneralInfo = new RecipeResponse() { Name = name },
                MashInfo = new RecipeMashResponse(),
                BatchInfo = new RecipeBatchResponse(),
            };
        }

        public RecipeResponseBuilder SetFieldsWithRecipe(Models.DB.Recipe recipe)
        {
            _recipeResponse.GeneralInfo.Id = recipe.Id;
            _recipeResponse.GeneralInfo.BLGScale = recipe.BLGScale;
            _recipeResponse.GeneralInfo.IBUScale = recipe.IBUScale;
            _recipeResponse.GeneralInfo.ABVScale = recipe.ABVScale;
            _recipeResponse.GeneralInfo.SRMScale = recipe.SRMScale;
            _recipeResponse.GeneralInfo.TypeId = recipe.Type?.Id;
            _recipeResponse.GeneralInfo.TypeName = recipe.Type?.Name;
            _recipeResponse.GeneralInfo.StyleId = recipe.Style?.Id;
            _recipeResponse.GeneralInfo.StyleName = recipe.Style?.Name;
            _recipeResponse.Info = recipe.Info;

            return this;
        }

        public RecipeResponseBuilder SetBatchInfo(Models.DB.Recipe recipe)
        {
            _recipeResponse.BatchInfo.ExpectedBeerVolume = recipe.ExpectedBeerVolume;
            _recipeResponse.BatchInfo.BoilTime = recipe.BoilTime;
            _recipeResponse.BatchInfo.EvaporationRate = recipe.EvaporationRate;
            _recipeResponse.BatchInfo.WortVolume = recipe.WortVolume;
            _recipeResponse.BatchInfo.BoilLoss = recipe.BoilLoss;
            _recipeResponse.BatchInfo.PreBoilGravity = recipe.PreBoilGravity;
            _recipeResponse.BatchInfo.FermentationLoss = recipe.FermentationLoss;
            _recipeResponse.BatchInfo.DryHopLoss = recipe.DryHopLoss;

            return this;
        }

        public RecipeResponseBuilder SetMashInfo(Models.DB.Recipe recipe)
        {
            _recipeResponse.MashInfo.MashEfficiency = recipe.MashEfficiency;
            _recipeResponse.MashInfo.WaterToGrainRatio = recipe.WaterToGrainRatio;
            _recipeResponse.MashInfo.MashWaterVolume = recipe.MashWaterVolume;
            _recipeResponse.MashInfo.TotalMashVolume = recipe.TotalMashVolume;

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
