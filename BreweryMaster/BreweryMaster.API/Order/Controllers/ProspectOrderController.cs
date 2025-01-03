using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.SharedModule.Validators;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<decimal> GetEstimatedPrice([FromQuery] ProspectPriceEstimationRequest request)
        {
            return _prospectOrderService.GetEstimatedPrice(request);
        }

        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(typeof(ProspectOrderDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProspectOrderDetails> GetProspectOrderDetails()
        {
            var prospectOrderDetails = _prospectOrderService.GetProspectOrderDetails();
            if (prospectOrderDetails == null)
                return NotFound();
            return Ok(prospectOrderDetails);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProspectOrder>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProspectOrder>>> GetProspectOrders()
        {
            var orders = await _prospectOrderService.GetProspectOrdersAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProspectOrder>> GetProspectOrderById([MinIntValidation] int id)
        {
            var order = await _prospectOrderService.GetProspectOrderByIdAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProspectOrder), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProspectOrder>> CreateProspectOrder([FromBody] ProspectOrderRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdOrder = await _prospectOrderService.CreateProspectOrderAsync(request);
            return CreatedAtAction(nameof(GetProspectOrderById), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditProspectOrder(int id, [FromBody] ProspectOrder order)
        {
            if (!await _prospectOrderService.EditProspectOrderAsync(id, order))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectOrder), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProspectOrderById([MinIntValidation] int id)
        {
            if (!await _prospectOrderService.DeleteProspectOrderByIdAsync(id))
                return NotFound();

            return Ok();
        }

        [HttpGet]
        [Route("testowo")]
        public ActionResult Testowo()
        {
            return Ok(_settings);
        }
    }
}
