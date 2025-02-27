using BreweryMaster.API.Recipe.Models;
using BreweryMaster.API.Recipe.Models.Requests;
using BreweryMaster.API.Recipe.Services;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(IEnumerable<RecipeDetailsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<RecipeDetailsResponse>>> GetRecipeDetails()
        {
            var recipes = await _recipeService.GetRecipeDetailsAsync();
            return Ok(recipes);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<RecipeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<RecipeResponse>>> GetRecipes([FromQuery] RecipeFilterRequest? request)
        {
            var recipes = await _recipeService.GetRecipes(request);
            return Ok(recipes);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(RecipeDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
            var beerStyles = await _recipeService.GetBeerStyleDropDownList();
            return Ok(beerStyles);
        }

        [HttpGet]
        [Route("Type/DropDown")]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetRecipeTypeDropDownList()
        {
            var recipeTypes = await _recipeService.GetRecipeTypeDropDownList();
            return Ok(recipeTypes);
        }

        [HttpPost]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(RecipeDetailsResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<RecipeDetailsResponse>> CreateRecipe([FromBody] RecipeRequest request)
        {
            var userContext = HttpContext.User;

            var createdRecipeDetails = await _recipeService.CreateRecipeDetailAsync(request, userContext);

            if (createdRecipeDetails == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetRecipeDetailsById), new { id = createdRecipeDetails.GeneralInfo.Id }, createdRecipeDetails);
        }
    }
}
