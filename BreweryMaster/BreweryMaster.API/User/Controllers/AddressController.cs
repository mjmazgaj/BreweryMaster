using BreweryMaster.API.Work.Services;
using BreweryMaster.API.User.Services;
using BreweryMaster.API.Shared.Validators;
using BreweryMaster.API.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Address>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            var addresses = await _addressService.GetAddressesAsync();
            if (addresses == null)
                return NotFound();

            return Ok(addresses);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Address>> GetAddressById([MinIntValidation] int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);

            if (address == null)
                return NotFound();

            return Ok(address);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Address), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Address>> CreateAddress([FromBody] Address address)
        {
            var createdAddress = await _addressService.CreateAddressAsync(address);
            return CreatedAtAction(nameof(GetAddressById), new { id = createdAddress.Id }, createdAddress);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditAddress(int id, [FromBody] Address address)
        {
            if (!await _addressService.EditAddressAsync(id, address))
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAddressById([MinIntValidation] int id)
        {
            if (!await _addressService.DeleteAddressByIdAsync(id))
                return NotFound();

            return Ok();
        }
    }
}
