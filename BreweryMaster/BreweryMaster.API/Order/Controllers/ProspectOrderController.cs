using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.OrderModules.Models;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BreweryMaster.API.OrderModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectOrderController : ControllerBase
    {
        private readonly IProspectOrderService _prospectOrderService;
        private readonly OrderSettings _settings;

        public ProspectOrderController(IProspectOrderService orderService, IOptions<OrderSettings> options)
        {
            _prospectOrderService = orderService;
            _settings = options.Value;
        }

        [HttpGet]
        [Route("Price")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> GetEstimatedPrice([FromQuery] ProspectPriceEstimationRequest request)
        {
            return await _prospectOrderService.GetEstimatedPrice(request);
        }

        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(typeof(ProspectOrderDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProspectOrderDetails>> GetProspectOrderDetails()
        {
            var prospectOrderDetails = await _prospectOrderService.GetProspectOrderDetails();

            if (prospectOrderDetails == null)
                return NotFound();

            return Ok(prospectOrderDetails);
        }

        [HttpGet]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(IEnumerable<ProspectOrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProspectOrderResponse>>> GetProspectOrders([FromQuery] ProspectOrderFilterRequest? request)
        {
            var orders = await _prospectOrderService.GetProspectOrdersAsync(request);
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProspectOrderResponse>> GetProspectOrderById([MinIntValidation] int id)
        {
            var order = await _prospectOrderService.GetProspectOrderByIdAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProspectOrder), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProspectOrderResponse>> CreateProspectOrder([FromBody] ProspectOrderRequest request)
        {
            var createdOrder = await _prospectOrderService.CreateProspectOrderAsync(request);

            if (createdOrder is null)
                return BadRequest();

            return CreatedAtAction(nameof(GetProspectOrderById), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "supervisor")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> EditProspectOrder([MinIntValidation] int id, [FromBody] ProspectOrderUpdateRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var isUpdated = await _prospectOrderService.EditProspectOrderAsync(id, request);

            if (!isUpdated)
                return NotFound();

            return Ok(isUpdated);
        }

        [HttpPatch]
        [Route("Delete/{id:int}")]
        [Authorize(Roles = "supervisor")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteProspectOrderById([MinIntValidation] int id)
        {
            var isDeleted = await _prospectOrderService.DeleteProspectOrderByIdAsync(id);

            if (!isDeleted)
                return NotFound();

            return Ok(isDeleted);
        }
    }
}
