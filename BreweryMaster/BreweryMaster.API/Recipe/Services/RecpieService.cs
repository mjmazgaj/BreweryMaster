using BreweryMaster.API.Recipe.Models;
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

        private bool RecpieExists(int id)
        {
            return _context.Recipes.Any(x => x.Id == id && !x.IsRemoved);
        }
    }
}
