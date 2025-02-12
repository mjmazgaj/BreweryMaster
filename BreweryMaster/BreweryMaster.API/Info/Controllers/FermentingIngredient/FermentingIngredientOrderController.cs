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
            var order = await _orderService.GetFermentingIngredientOrderById(id);

            if (order == null)
                return NotFound();

            return Ok(order);
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

        [HttpPatch]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> UpdateFermentingIngredientOrder([MinIntValidation] int id, FermentingIngredientOrderUpdateRequest request)
        {
            if (request.Id != id)
                return BadRequest();

            var updateSuccessful = await _orderService.UpdateFermentingIngredientOrder(id, request);

            if (updateSuccessful)
                return Ok();

            return NotFound();
        }

        [HttpPatch]
        [Route("Complete/{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> CompleteFermentingIngredientOrder([MinIntValidation] int id)
        {
            var completionSuccessful = await _orderService.CompleteFermentingIngredientOrder(id);

            if (completionSuccessful)
                return Ok();

            return NotFound();
        }

        [HttpPatch]
        [Route("Delete/{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteFermentingIngredientOrder([MinIntValidation] int id)
        {
            var deletedSuccessful = await _orderService.DeleteFermentingIngredientOrder(id);

            if (deletedSuccessful)
                return Ok();

            return NotFound();
        }
    }
}
