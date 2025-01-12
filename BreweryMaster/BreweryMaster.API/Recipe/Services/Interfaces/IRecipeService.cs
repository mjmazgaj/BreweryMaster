using BreweryMaster.API.Recipe.Models;

namespace BreweryMaster.API.Recipe.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDetailsResponse>> GetRecipesAsync();
    }
}