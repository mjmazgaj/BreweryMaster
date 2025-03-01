using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientReservationResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientReservationResponse>>> GetFermentingIngredientReservations()
        {
            var reservations = await _reservationService.GetFermentingIngredientReservations();
            return Ok(reservations);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(FermentingIngredientReservationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FermentingIngredientReservationResponse>> GetFermentingIngredientReservationById([MinIntValidation] int id)
        {
            var reservation = await _reservationService.GetFermentingIngredientReservationById(id);

            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpPost]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(FermentingIngredientReservationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<FermentingIngredientReservationResponse>> CreateFermentingIngredientReservation(FermentingIngredientReserveRequest request)
        {
            var createdReservation = await _reservationService.CreateFermentingIngredientReservation(request);

            if (createdReservation == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetFermentingIngredientReservationById), new { id = createdReservation.Id }, createdReservation);
        }

        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> UpdateFermentingIngredientReservation([MinIntValidation] int id, FermentingIngredientQuantityUpdateRequest request)
        {
            if (request.Id != id)
                return BadRequest();

            var isUpdated = await _reservationService.UpdateFermentingIngredientReservation(id, request);

            if (!isUpdated)
                return NotFound();

            return Ok();
        }

        [HttpPatch]
        [Route("Complete/{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> CompleteFermentingIngredientReservation([MinIntValidation] int id)
        {
            var isComplated = await _reservationService.CompleteFermentingIngredientReservation(id);

            if (!isComplated)
                return NotFound();

            return Ok();
        }

        [HttpPatch]
        [Route("Delete/{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteFermentingIngredientReservation([MinIntValidation] int id)
        {
            var isDeleted = await _reservationService.DeleteFermentingIngredientReservation(id);

            if (!isDeleted)
                return NotFound();

            return Ok();
        }
    }
}
