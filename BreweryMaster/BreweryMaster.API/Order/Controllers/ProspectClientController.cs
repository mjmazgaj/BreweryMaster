using Azure.Core;
using BreweryMaster.API.Order.Models;
using BreweryMaster.API.Shared.Validators;
using BreweryMaster.API.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectClientController : ControllerBase
    {
        private readonly IProspectClientService _clientService;

        public ProspectClientController(IProspectClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProspectClient>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProspectClient>>> GetProspectClients()
        {
            var clients = await _clientService.GetProspectClientsAsync();
            if (clients == null)
                return NotFound();
            return Ok(clients);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectClient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProspectClient>> GetProspectClientById([MinIntValidation] int id)
        {
            var client = await _clientService.GetProspectClientByIdAsync(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProspectClient), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProspectClient>> CreateProspectClient([FromBody] ProspectClientRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdClient = await _clientService.CreateProspectClientAsync(request);
            return CreatedAtAction(nameof(GetProspectClientById), new { id = createdClient.ID }, createdClient);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectClient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditProspectClient(int id, [FromBody] ProspectClient client)
        {
            if (!await _clientService.EditProspectClientAsync(id, client))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ProspectClient), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProspectClientById([MinIntValidation] int id)
        {
            if (!await _clientService.DeleteProspectClientByIdAsync(id))
                return NotFound();

            return Ok();
        }
    }
}
