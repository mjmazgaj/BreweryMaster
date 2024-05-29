using BreweryMaster.API.Models.User;
using BreweryMaster.API.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiDoReacta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly UserContext _userContext;
        public ClientController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Client>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            if (_userContext.Clients == null)
                return NotFound();
            return await _userContext.Clients.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetClientById([MinIntValidation] int id)
        {
            if (_userContext.Clients == null)
                return NotFound();

            var client = await _userContext.Clients.FirstOrDefaultAsync(x => x.ID == id);

            if (client == null)
                return NotFound();

            return client;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Client), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Client>> CreateClient([FromBody] Client client)
        {
            var clientToCreate = new Client()
            {
                Forename = client.Forename,
                Surname = client.Surname,
                CompanyName = client.CompanyName,
                NIP = client.NIP,
                AddressId = client.AddressId,
                DeliveryAddressId = client.DeliveryAddressId,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email
            };

            _userContext.Clients.Add(clientToCreate);
            await _userContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientById), new { id = clientToCreate.ID }, clientToCreate);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> EditClient([MinIntValidation] int id, [FromBody] Client client)
        {
            if (id != client.ID)
                return BadRequest();

            _userContext.Entry(client).State = EntityState.Modified;

            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                    return NotFound();
                else
                    throw;
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> DeleteClientById([MinIntValidation] int id)
        {
            if (_userContext.Clients == null)
                return NotFound();

            var client = await _userContext.Clients.FirstOrDefaultAsync(x => x.ID == id);

            if (client == null)
                return NotFound();

            _userContext.Clients.Remove(client);
            await _userContext.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            return _userContext.Clients.Any(x => x.ID == id);
        }

    }
}
