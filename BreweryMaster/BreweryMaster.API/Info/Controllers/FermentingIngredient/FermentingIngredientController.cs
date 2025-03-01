using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FermentingIngredientController : ControllerBase
    {
        private readonly IFermentingIngredientService _fermentingIngredientService;

        public FermentingIngredientController(IFermentingIngredientService fermentingIngredientService)
        {
            _fermentingIngredientService = fermentingIngredientService;
        }

        [HttpGet]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientResponse>>> GetFermentingIngredient()
        {
            var fermentingIngredients = await _fermentingIngredientService.GetFermentingIngredientsAsync();
            return Ok(fermentingIngredients);
        }

        [HttpGet]
        [Route("Summary")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientSummaryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientSummaryResponse>>> GetFermentingIngredientSummary([FromQuery] FermentingIngredientFilterRequest? request)
        {
            var fermentingIngredientsSummary = await _fermentingIngredientService.GetFermentingIngredientSummary(request);
            return Ok(fermentingIngredientsSummary);
        }

        [HttpGet]
        [Route("Summary/{id:int}")]
        [ProducesResponseType(typeof(FermentingIngredientSummaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FermentingIngredientSummaryResponse>> GetFermentingIngredientSummaryById([MinIntValidation] int id)
        {
            var fermentingIngredient = await _fermentingIngredientService.GetFermentingIngredientSummaryByIdAsync(id);

            if (fermentingIngredient == null)
                return NotFound();

            return Ok(fermentingIngredient);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(FermentingIngredientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FermentingIngredientResponse>> GetFermentingIngredientById([MinIntValidation] int id)
        {
            var fermentingIngredient = await _fermentingIngredientService.GetFermentingIngredientByIdAsync(id);

            if (fermentingIngredient == null)
                return NotFound();

            return Ok(fermentingIngredient);
        }

        [HttpGet]
        [Route("Unit")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientUnitResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientUnitResponse>>> GetFermentingIngredientUnit()
        {
            var fermentingIngredientUnit = await _fermentingIngredientService.GetFermentingIngredientUnitAsync();
            return Ok(fermentingIngredientUnit);
        }

        [HttpGet]
        [Route("Units/{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<int>?>> GetFermentingIngredientUnitsById([MinIntValidation] int id)
        {
            var fermentingIngredientUnits = await _fermentingIngredientService.GetFermentingIngredientUnitsById(id);

            if (fermentingIngredientUnits == null)
                return NotFound();

            return Ok(fermentingIngredientUnits);
        }

        [HttpGet]
        [Route("Type")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientTypeEntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientTypeEntityResponse>>> GetFermentingIngredientTypes()
        {
            var fermentingIngredientTypes = await _fermentingIngredientService.GetFermentingIngredientTypesAsync();
            return Ok(fermentingIngredientTypes);
        }

        [HttpPost]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(FermentingIngredientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FermentingIngredientResponse>> CreateFermentingIngredient([FromBody] FermentingIngredientRequest request)
        {
            var createdFermentingIngredient = await _fermentingIngredientService.CreateFermentingIngredientAsync(request);

            if (createdFermentingIngredient is null)
                return BadRequest();

            return CreatedAtAction(nameof(GetFermentingIngredientById), new { id = createdFermentingIngredient.Id }, createdFermentingIngredient);
        }

        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> UpdateFermentingIngredient(int id, [FromBody] FermentingIngredientUpdateRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var isUpdated = await _fermentingIngredientService.UpdateFermentingIngredientAsync(id, request);

            if (!isUpdated)
                return NotFound();

            return Ok();
        }

        [HttpPatch]
        [Route("Unit/{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> UpdateFermentingIngredientUnits(int id, [FromBody] FermentingIngredientUnitsUpdateRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var isUpdated = await _fermentingIngredientService.UpdateFermentingIngredientUnits(id, request);

            if (!isUpdated)
                return NotFound();

            return Ok();
        }

        [HttpPatch]
        [Route("Delete/{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteFermentingIngredientUnitById([MinIntValidation] int id)
        {
            var isDeleted = await _fermentingIngredientService.DeleteFermentingIngredientUnitById(id);

            if (!isDeleted)
                return NotFound();

            return Ok();
        }
    }
}
