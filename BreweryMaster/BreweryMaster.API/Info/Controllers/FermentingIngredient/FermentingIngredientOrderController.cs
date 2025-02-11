using BreweryMaster.API.Info.Models;
using BreweryMaster.API.Info.Services;
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
    }
}
