using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.SharedModule.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BreweryMaster.API.OrderModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectClientController : ControllerBase
    {
        private readonly IProspectClientService _clientService;
        private readonly OrderSettings _settings;

        public ProspectClientController(IProspectClientService clientService,  IOptions<OrderSettings> options)
        {
            _clientService = clientService;
            _settings = options.Value;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProspectClientResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProspectClientResponse>>> GetProspectClients()
        {
            var clients = await _clientService.GetProspectClientsAsync();
            return Ok(clients);
        }

        [HttpGet]
        [Route("DropDown")]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetProspectClientDropDownList()
        {
            var clients = await _clientService.GetProspectClientDropDownList();
            return Ok(clients);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProspectClientResponse>> GetProspectClientById([MinIntValidation] int id)
        {
            var client = await _clientService.GetProspectClientByIdAsync(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProspectClientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProspectClientResponse>> CreateProspectClient([FromBody] ProspectClientRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdClient = await _clientService.CreateProspectClientAsync(request);
            return CreatedAtAction(nameof(GetProspectClientById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditProspectClient(int id, [FromBody] ProspectClientResponse client)
        {
            if (!await _clientService.EditProspectClientAsync(id, client))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProspectClientById([MinIntValidation] int id)
        {
            if (!await _clientService.DeleteProspectClientByIdAsync(id))
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
