using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Info.Controllers.FermentingIngredient
{
    [Route("api/FermentingIngredient/Reservation")]
    [ApiController]
    public class FermentingIngredientReservationController : ControllerBase
    {
        private readonly IFermentingIngredientReservationService _reservationService;

        public FermentingIngredientReservationController(IFermentingIngredientReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientReservationResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientReservationResponse>>> GetFermentingIngredientReservations()
        {
            var fermentingIngredientReservations = await _reservationService.GetFermentingIngredientReservations();
            return Ok(fermentingIngredientReservations);
        }

        [HttpPatch]
        [Route("Complete/{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> CompleteFermentingIngredientReservation([MinIntValidation] int id)
        {
            var completionSuccessful = await _reservationService.CompleteFermentingIngredientReservation(id);

            if(completionSuccessful)
                return Ok();

            return NotFound();
        }

        [HttpPatch]
        [Route("Delete/{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteFermentingIngredientReservation([MinIntValidation] int id)
        {
            var deletedSuccessful = await _reservationService.DeleteFermentingIngredientReservation(id);

            if (deletedSuccessful)
                return Ok();

            return NotFound();
        }
    }
}
