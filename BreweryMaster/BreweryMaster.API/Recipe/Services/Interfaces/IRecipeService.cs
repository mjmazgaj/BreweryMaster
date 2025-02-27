using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Models.Requests;
using BreweryMaster.API.Shared.Models;
using System.Security.Claims;

namespace BreweryMaster.API.Recipe.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDetailsResponse>> GetRecipeDetailsAsync();
        Task<IEnumerable<RecipeResponse>> GetRecipesAsync(RecipeFilterRequest? request);
        Task<RecipeDetailsResponse?> GetRecipeDetailByIdAsync(int id);
        Task<IEnumerable<EntityResponse>?> GetBeerStyleDropDownList();
        Task<IEnumerable<EntityResponse>?> GetRecipeTypeDropDownList();
        Task<RecipeDetailsResponse?> CreateRecipeDetailAsync(RecipeRequest request, ClaimsPrincipal? claims);
    }
}