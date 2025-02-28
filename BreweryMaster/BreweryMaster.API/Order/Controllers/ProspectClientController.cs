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
    public class ProspectClientController : ControllerBase
    {
        private readonly IProspectClientService _clientService;
        private readonly OrderSettings _settings;

        public ProspectClientController(IProspectClientService clientService, IOptions<OrderSettings> options)
        {
            _clientService = clientService;
            _settings = options.Value;
        }

        [HttpGet]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(IEnumerable<ProspectClientResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProspectClientResponse>>> GetProspectClients()
        {
            var clients = await _clientService.GetProspectClientsAsync();
            return Ok(clients);
        }

        [HttpGet]
        [Route("DropDown")]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EntityResponse>>> GetProspectClientDropDownList()
        {
            var clients = await _clientService.GetProspectClientDropDownList();
            return Ok(clients);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(ProspectClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
            var createdClient = await _clientService.CreateProspectClientAsync(request);
            return CreatedAtAction(nameof(GetProspectClientById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "supervisor")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> EditProspectClient([MinIntValidation] int id, [FromBody] ProspectClientUpdateRequest request)
        {
            if(id != request.Id)
                return BadRequest();

            var isupdated = await _clientService.EditProspectClientAsync(id, request);

            if (!isupdated)
                return NotFound();

            return Ok(isupdated);
        }

        [HttpPatch]
        [Route("Delete/{id:int}")]
        [Authorize(Roles = "supervisor")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteProspectClientById([MinIntValidation] int id)
        {
            var isDeleted = await _clientService.DeleteProspectClientByIdAsync(id);

            if (!isDeleted)
                return NotFound();

            return Ok(isDeleted);
        }
    }
}
