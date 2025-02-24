using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Models.DB;
using BreweryMaster.API.Recipe.Models.Requests;
using BreweryMaster.API.Recipe.Services.ResponseBuilders;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.Shared.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
                    .ThenInclude(x => x.Type)
                .Include(x => x.FermentingIngredients)
                    .ThenInclude(x => x.FermentingIngredientUnit)
                    .ThenInclude(x => x.Unit)
                .Include(x => x.Hops)
                    .ThenInclude(x=>x.HopUnit)
                    .ThenInclude(x=>x.Unit)
                .Include(x => x.Hops)
                    .ThenInclude(x => x.HopUnit)
                    .ThenInclude(x => x.Hop)
                .Include(x=>x.Yeast)
                    .ThenInclude(x=>x.YeastUnit)
                    .ThenInclude(x=>x.Unit)
                .Include(x => x.Yeast)
                    .ThenInclude(x => x.YeastUnit)
                    .ThenInclude(x => x.Yeast)
                    .ThenInclude(x => x.Form)
                .Include(x => x.Yeast)
                    .ThenInclude(x => x.YeastUnit)
                    .ThenInclude(x => x.Yeast)
                    .ThenInclude(x => x.Type)
                .ToListAsync();

            return recipes.Select(recipe =>
            {
                var responseBuilder = new RecipeResponseBuilder(recipe.Name);
                responseBuilder.SetFieldsWithRecipe(recipe);
                responseBuilder.SetBatchInfo(recipe);
                responseBuilder.SetMashInfo(recipe);
                responseBuilder.SetFermentingIngredients(recipe.FermentingIngredients);
                responseBuilder.SetHops(recipe.Hops);
                responseBuilder.SetYeast(recipe.Yeast);

                return responseBuilder.Build();
            });
        }

        public async Task<IEnumerable<RecipeResponse>> GetRecipesAsync(RecipeFilterRequest? request = null)
        {
            var recipes = new List<Recipe.Models.DB.Recipe>();

            if (request == null)
            {
                recipes = await _context.Recipes
                    .Where(x => !x.IsRemoved)
                    .Include(x => x.Type)
                    .Include(x => x.Style)
                    .ToListAsync();
            }
            else
            {
                recipes = await _context.Recipes
                    .Where(x => !x.IsRemoved)
                    .Include(x => x.Type)
                    .Include(x => x.Style)
                        .Where(x => request.TypeId == null || x.TypeId == request.TypeId)
                        .Where(x => request.BeerStyleId == null || x.StyleId== request.BeerStyleId)
                        .Where(x => request.Name == null || x.Name.ToLower().Contains(request.Name.ToLower()))
                    .ToListAsync();
            }

            return recipes.Select(x => new RecipeResponse()
            {
                Id = x.Id,
                Name = x.Name,
                BLGScale = x.BLGScale,
                IBUScale = x.IBUScale,
                ABVScale = x.ABVScale,
                SRMScale = x.SRMScale,
                TypeId = x.Type?.Id,
                TypeName = x.Type?.Name,
                StyleName = x.Style?.Name,
                StyleId = x.Style?.Id,
            });
        }
        public async Task<RecipeDetailsResponse?> GetRecipeDetailByIdAsync(int id)
        {
            var recipes = await GetRecipeDetailsAsync();

            return recipes.FirstOrDefault(x => x.GeneralInfo.Id == id);
        }

        public async Task<IEnumerable<EntityResponse>?> GetBeerStyleDropDownList()
        {
            return await _context.BeerStyles
                .Select(x => new EntityResponse()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<EntityResponse>?> GetRecipeTypeDropDownList()
        {
            return await _context.RecipeTypes
                .Select(x => new EntityResponse()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }

        public async Task<RecipeDetailsResponse?> CreateRecipeDetailAsync(RecipeDetailsRequest request, ClaimsPrincipal? claims)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var nameIdClaim = claims?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (nameIdClaim is null)
                throw new ArgumentNullException("Cant find logged user");

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
                    Price = request.Price,
                    Info = request.Info,
                    CreatedById = nameIdClaim.Value,
                    CreatedOn = DateTime.Now
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
