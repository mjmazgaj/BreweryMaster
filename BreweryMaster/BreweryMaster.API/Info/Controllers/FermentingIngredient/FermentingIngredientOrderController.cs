using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Info.Controllers.FermentingIngredient
{
    [Route("api/FermentingIngredient/Order")]
    [ApiController]
    public class FermentingIngredientOrderController : ControllerBase
    {
        private readonly IFermentingIngredientOrderService _orderService;

        public FermentingIngredientOrderController(IFermentingIngredientOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientOrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientOrderResponse>>> GetFermentingIngredientOrders()
        {
            var fermentingIngredientOrders = await _orderService.GetFermentingIngredientOrders();
            return Ok(fermentingIngredientOrders);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(FermentingIngredientOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FermentingIngredientOrderResponse>> GetFermentingIngredientOrderById([MinIntValidation] int id)
        {
            var reservation = await _orderService.GetFermentingIngredientOrderById(id);

            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FermentingIngredientOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FermentingIngredientOrderResponse>> CreateFermentingIngredientOrder(FermentingIngredientOrderRequest request)
        {
            var createdOrder = await _orderService.CreateFermentingIngredientOrder(request);

            if (createdOrder == null)
                return BadRequest();

            return CreatedAtAction(nameof(_orderService), new { id = createdOrder.Id }, createdOrder);
        }
    }
}
