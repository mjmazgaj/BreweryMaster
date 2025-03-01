using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(IEnumerable<FermentingIngredientOrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<FermentingIngredientOrderResponse>>> GetFermentingIngredientOrders()
        {
            var fermentingIngredientOrders = await _orderService.GetFermentingIngredientOrders();
            return Ok(fermentingIngredientOrders);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(FermentingIngredientOrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FermentingIngredientOrderResponse>> GetFermentingIngredientOrderById([MinIntValidation] int id)
        {
            var order = await _orderService.GetFermentingIngredientOrderById(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(FermentingIngredientOrderResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<FermentingIngredientOrderResponse>> CreateFermentingIngredientOrder(FermentingIngredientOrderRequest request)
        {
            var createdOrder = await _orderService.CreateFermentingIngredientOrder(request);

            if (createdOrder == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetFermentingIngredientOrderById), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "brewer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> UpdateFermentingIngredientOrder([MinIntValidation] int id, FermentingIngredientOrderUpdateRequest request)
        {
            if (request.Id != id)
                return BadRequest();

            var isUpdated = await _orderService.UpdateFermentingIngredientOrder(id, request);

            if (!isUpdated)
                return NotFound();

            return Ok();
        }

        [HttpPatch]
        [Authorize(Roles = "brewer")]
        [Route("Complete/{id:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> CompleteFermentingIngredientOrder([MinIntValidation] int id)
        {
            var isCompleted = await _orderService.CompleteFermentingIngredientOrder(id);

            if (!isCompleted)
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
        public async Task<ActionResult<bool>> DeleteFermentingIngredientOrder([MinIntValidation] int id)
        {
            var isDeleted = await _orderService.DeleteFermentingIngredientOrder(id);

            if (!isDeleted)
                return NotFound();

            return Ok();
        }
    }
}
