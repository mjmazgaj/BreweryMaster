using BreweryMaster.API.Recipe.Models;
using System.Security.Claims;

namespace BreweryMaster.API.Recipe.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDetailsResponse>> GetRecipeDetailsAsync();
        Task<IEnumerable<RecipeResponse>> GetRecipesAsync();
        Task<RecipeDetailsResponse?> GetRecipeDetailByIdAsync(int id);
        Task<RecipeDetailsResponse?> CreateRecipeDetailAsync(RecipeDetailsRequest request, ClaimsPrincipal? claims);
    }
}