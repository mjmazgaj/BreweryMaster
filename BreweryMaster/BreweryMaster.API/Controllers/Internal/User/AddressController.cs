using BreweryMaster.API.Models.User;
using BreweryMaster.API.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiDoReacta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly UserContext _addressContext;
        public AddressController(UserContext addressContext)
        {
            _addressContext = addressContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Address>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            if (_addressContext.Addresses == null)
                return NotFound();
            return await _addressContext.Addresses.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Address>> GetAddressById([MinIntValidation] int id)
        {
            if (_addressContext.Addresses == null)
                return NotFound();

            var address = await _addressContext.Addresses.FirstOrDefaultAsync(x => x.ID == id);

            if (address == null)
                return NotFound();

            return address;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Address), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Address>> CreateAddress([FromBody] Address address)
        {
            var addressToCreate = new Address()
            {
                City = address.City,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                ApartamentNumber = address.ApartamentNumber,
                PostalCode = address.PostalCode,
                Country = address.Country,
                Region = address.Region,
                Commune = address.Commune
            };

            _addressContext.Addresses.Add(addressToCreate);
            await _addressContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAddressById), new { id = addressToCreate.ID }, addressToCreate);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Address>> EditAddress(int id, [FromBody] Address address)
        {
            if (id != address.ID)
                return BadRequest();

            _addressContext.Entry(address).State = EntityState.Modified;

            try
            {
                await _addressContext.SaveChangesAsync();
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
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Address>> DeleteAddressById([MinIntValidation] int id)
        {
            if (_addressContext.Addresses == null)
                return NotFound();

            var address = await _addressContext.Addresses.FirstOrDefaultAsync(x => x.ID == id);

            if (address == null)
                return NotFound();

            _addressContext.Addresses.Remove(address);
            await _addressContext.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            return _addressContext.Addresses.Any(x => x.ID == id);
        }

    }
}
