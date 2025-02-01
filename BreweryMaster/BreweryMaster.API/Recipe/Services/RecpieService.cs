using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Models.DB;
using BreweryMaster.API.Recipe.Services.Interfaces;
using BreweryMaster.API.Recipe.Services.ResponseBuilders;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace BreweryMaster.API.Recipe.Services
{
    public class RecpieService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecpieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeDetailsResponse>> GetRecipeDetailsAsync()
        {
            var recipes = await _context.Recipes
                .Where(x => !x.IsRemoved)
                .Include(x => x.Type)
                .Include(x => x.Style)
                .Include(x => x.FermentingIngredients)
                    .ThenInclude(x => x.FermentingIngredientUnit)
                    .ThenInclude(x => x.FermentingIngredient)
                .Include(x => x.FermentingIngredients)
                    .ThenInclude(x => x.FermentingIngredientUnit)
                    .ThenInclude(x => x.Unit)
                .ToListAsync();

            var dbIngredientTypes = await _context.FermentingIngredientTypes
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            return recipes.Select(recipe =>
            {
                var responseBuilder = new RecipeResponseBuilder(recipe.Name);
                responseBuilder.SetFieldsWithRecipe(recipe);
                responseBuilder.SetFermentingIngredients(recipe.FermentingIngredients, dbIngredientTypes);

                return responseBuilder.Build();
            });
        }

        public async Task<IEnumerable<RecipeResponse>> GetRecipesAsync()
        {
            var recipes = await _context.Recipes
                .Where(x => !x.IsRemoved)
                .Include(x => x.Type)
                .Include(x => x.Style)
                .ToListAsync();

            return recipes.Select(x => new RecipeResponse()
            {
                Id = x.Id,
                Name = x.Name,
                BLGScale = x.BLGScale,
                IBUScale = x.IBUScale,
                ABVScale = x.ABVScale,
                SRMScale = x.SRMScale,
                TypeName = x.Type?.Name,
                StyleName = x.Style?.Name,
            });
        }
        public async Task<RecipeDetailsResponse?> GetRecipeDetailByIdAsync(int id)
        {
            var recipes = await GetRecipeDetailsAsync();

            return recipes.FirstOrDefault(x => x.Id == id);
        }
        public async Task<RecipeDetailsResponse?> CreateRecipeDetailAsync(RecipeDetailsRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var recipeToCreate = new Models.DB.Recipe()
                {
                    Name = request.Name,
                    BLGScale = request.BLGScale,
                    IBUScale = request.IBUScale,
                    ABVScale = request.ABVScale,
                    SRMScale = request.SRMScale,
                    TypeId = request.TypeId,
                    StyleId = request.StyleId,
                    ExpectedBeerVolume = request.ExpectedBeerVolume,
                    BoilTime = request.BoilTime,
                    EvaporationRate = request.EvaporationRate,
                    WortVolume = request.WortVolume,
                    BoilLoss = request.BoilLoss,
                    PreBoilGravity = request.PreBoilGravity,
                    FermentationLoss = request.FermentationLoss,
                    DryHopLoss = request.DryHopLoss,
                    MashEfficiency = request.MashEfficiency,
                    WaterToGrainRatio = request.WaterToGrainRatio,
                    MashWaterVolume = request.MashWaterVolume,
                    TotalMashVolume = request.TotalMashVolume,
                };

                _context.Recipes.Add(recipeToCreate);
                await _context.SaveChangesAsync();

                var recipeFermentingIngredientUnitsToCreate = request.FermentingIngredients?
                    .Select(x => new RecipeFermentingIngredient()
                    {
                        RecipeId = recipeToCreate.Id,
                        Recipe = null!,
                        FermentingIngredientUnitId = x.Key,
                        FermentingIngredientUnit = null!,
                        Quantity = x.Value.Quantity,
                        Info = x.Value.Info
                    });

                if (recipeFermentingIngredientUnitsToCreate is not null)
                    _context.RecipeFermentingIngredients.AddRange(recipeFermentingIngredientUnitsToCreate);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return await GetRecipeDetailByIdAsync(recipeToCreate.Id);

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
        }

        private bool RecpieExists(int id)
        {
            return _context.Recipes.Any(x => x.Id == id && !x.IsRemoved);
        }
    }
}
