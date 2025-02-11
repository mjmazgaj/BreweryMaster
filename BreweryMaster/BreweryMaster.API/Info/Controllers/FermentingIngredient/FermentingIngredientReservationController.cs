using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
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
    }
}
