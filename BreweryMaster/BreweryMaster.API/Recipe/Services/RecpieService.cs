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
        public async Task<IEnumerable<RecipeResponse>> GetRecipesAsync()
        {
            var recipes = await _context.Recipes
                .Where(x => !x.IsRemoved)
                .Include(x => x.Type)
                .Include(x => x.Style)
                .ToListAsync();

            var fermentingIngredients = await _context.RecipeFermentingIngredients
                .Include(x => x.Recipe)
                .Include(x => x.FermentingIngredient)
                .ToListAsync();

            return recipes.Select(x =>
            {
                var responseBuilder = new RecipeResponseBuilder(x.Name);
                responseBuilder.SetFieldsWithResponse(x);
                responseBuilder.SetFermentingIngredients(fermentingIngredients, x.Id);
                return responseBuilder.Build();
            });
        }

        private bool RecpieExists(int id)
        {
            return _context.Recipes.Any(x => x.Id == id && !x.IsRemoved);
        }
    }
}
