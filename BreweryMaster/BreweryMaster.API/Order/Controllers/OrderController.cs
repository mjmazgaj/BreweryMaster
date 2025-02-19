﻿using BreweryMaster.API.Info.Models;
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
        [Route("All")]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders()
        {
            var clients = await _clientService.GetOrders();
            return Ok(clients);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetCurrentUserOrders()
        {
            var clients = await _clientService.GetCurrentUserOrders(HttpContext.User);
            return Ok(clients);
        }

        [HttpGet]
        [Route("Status")]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetOrderStatuses()
        {
            var clients = await _clientService.GetOrderStatuses();
            return Ok(clients);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderResponse>> GetOrderById([MinIntValidation] int id)
        {
            var client = await _clientService.GetOrderByIdAsync(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpGet]
        [Route("Details/{id:int}")]
        [ProducesResponseType(typeof(OrderDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDetailsResponse>> GetOrderDetailsById([MinIntValidation] int id)
        {
            var client = await _clientService.GetOrderDetailById(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }


        [HttpGet]
        [Route("Price")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<decimal>> GetOrderPrice([FromQuery] OrderPriceRequest request)
        {
            var price = await _clientService.GetOrderPrice(request);

            return Ok(price);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] OrderRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdClient = await _clientService.CreateOrderAsync(request, HttpContext.User);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPost]
        [Route("Status")]
        [ProducesResponseType(typeof(OrderStatusChangeResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderStatusChangeResponse>> CreateOrderStatusChange(OrderStatusChangeRequest request)
        {
            var createOrderStatusChange = await _clientService.CreateOrderStatusChange(request);
            return Ok(createOrderStatusChange);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditOrder(int id, [FromBody] OrderUpdateRequest client)
        {
            if (!await _clientService.EditOrderAsync(id, client))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(OrderResponse), StatusCodes.Status200OK)]
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
