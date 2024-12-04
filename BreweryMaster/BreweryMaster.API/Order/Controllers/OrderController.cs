using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.SharedModule.Validators;
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
        [ProducesResponseType(typeof(IEnumerable<Order>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Order>>> GetProspectOrders()
        {
            var clients = await _clientService.GetOrdersAsync();
            if (clients == null)
                return NotFound();
            return Ok(clients);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Order>> GetOrderById([MinIntValidation] int id)
        {
            var client = await _clientService.GetOrderByIdAsync(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Order), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdClient = await _clientService.CreateOrderAsync(request);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditOrder(int id, [FromBody] Order client)
        {
            if (!await _clientService.EditOrderAsync(id, client))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrderById([MinIntValidation] int id)
        {
            if (!await _clientService.DeleteOrderByIdAsync(id))
                return NotFound();

            return Ok();
        }
    }
}
