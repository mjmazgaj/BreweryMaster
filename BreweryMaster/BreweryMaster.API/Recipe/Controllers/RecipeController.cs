using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RecipeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RecipeResponse>>> GetRecipes()
        {
            var recipes = await _recipeService.GetRecipesAsync();
            return Ok(recipes);
        }
    }
}
