using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BreweryMaster.API.OrderModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _clientService;
        private readonly OrderSettings _settings;

        public OrderController(IOrderService clientService, IOptions<OrderSettings> options)
        {
            _clientService = clientService;
            _settings = options.Value;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders([FromQuery] OrderFilterRequest? request)
        {
            var orders = await _clientService.GetOrders(request);
            return Ok(orders);
        }

        [HttpGet]
        [Route("DropDown")]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetOrderDropDownList()
        {
            var orders = await _clientService.GetOrderDropDownList();
            return Ok(orders);
        }

        [HttpGet]
        [Authorize(Roles = "customer")]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetCurrentUserOrders()
        {
            var orders = await _clientService.GetCurrentUserOrders(HttpContext.User);
            return Ok(orders);
        }

        [HttpGet]
        [Route("Status")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetOrderStatuses()
        {
            var orders = await _clientService.GetOrderStatuses();
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderResponse>> GetOrderById([MinIntValidation] int id)
        {
            var orders = await _clientService.GetOrderByIdAsync(id);

            if (orders == null)
                return NotFound();

            return Ok(orders);
        }

        [HttpGet]
        [Route("Details/{id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(OrderDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDetailsResponse>> GetOrderDetailsById([MinIntValidation] int id)
        {
            var orders = await _clientService.GetOrderDetailById(id);

            if (orders == null)
                return NotFound();

            return Ok(orders);
        }


        [HttpGet]
        [Route("Price")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal>> GetOrderPrice([FromQuery] OrderPriceRequest request)
        {
            var price = await _clientService.GetOrderPrice(request);

            if (price is null)
                return BadRequest();

            return Ok(price);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] OrderRequest request)
        {
            var createdClient = await _clientService.CreateOrderAsync(request, HttpContext.User);

            if (createdClient == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetOrderById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPost]
        [Route("Status")]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(OrderStatusChangeResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderStatusChangeResponse>> CreateOrderStatusChange(OrderStatusChangeRequest request)
        {
            var createOrderStatusChange = await _clientService.CreateOrderStatusChange(request);
            return Ok(createOrderStatusChange);
        }

        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "supervisor")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditOrder([MinIntValidation] int id, [FromBody] OrderUpdateRequest orders)
        {
            var isUpdated = await _clientService.EditOrderAsync(id, orders);

            if (!isUpdated)
                return NotFound();

            return Ok(isUpdated);
        }

        [HttpPatch]
        [Route("Delete/{id:int}")]
        [Authorize(Roles = "manager")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrderById([MinIntValidation] int id)
        {
            var isUpdated = await _clientService.DeleteOrderByIdAsync(id);

            if (!isUpdated)
                return NotFound();

            return Ok(isUpdated);
        }
    }
}
