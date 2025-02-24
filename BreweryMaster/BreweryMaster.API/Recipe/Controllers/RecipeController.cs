using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Services;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.SharedModule.Validators;
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
        [Route("Details")]
        [ProducesResponseType(typeof(IEnumerable<RecipeDetailsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RecipeDetailsResponse>>> GetRecipeDetails()
        {
            var recipes = await _recipeService.GetRecipeDetailsAsync();
            return Ok(recipes);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RecipeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RecipeResponse>>> GetRecipes()
        {
            var recipes = await _recipeService.GetRecipesAsync();
            return Ok(recipes);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(RecipeDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RecipeDetailsResponse>> GetRecipeDetailsById([MinIntValidation] int id)
        {
            var recipeDetails = await _recipeService.GetRecipeDetailByIdAsync(id);

            if (recipeDetails == null)
                return NotFound();

            return Ok(recipeDetails);
        }

        [HttpGet]
        [Route("BeerStyle/DropDown")]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetBeerStyleDropDownList()
        {
            var recipes = await _recipeService.GetBeerStyleDropDownList();
            return Ok(recipes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RecipeDetailsResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RecipeDetailsResponse>> CreateRecipe([FromBody] RecipeDetailsRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userContext = HttpContext.User;

            var createdRecipeDetails = await _recipeService.CreateRecipeDetailAsync(request, userContext);

            if (createdRecipeDetails == null)
                return UnprocessableEntity();

            return CreatedAtAction(nameof(GetRecipeDetailsById), new { id = createdRecipeDetails.GeneralInfo.Id }, createdRecipeDetails);
        }
    }
}
