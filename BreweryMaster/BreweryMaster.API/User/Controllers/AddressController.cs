using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.SharedModule.Validators;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.User.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Route("{id:int}")]
        [Authorize]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressResponse>> GetAddressById([MinIntValidation] int id)
        {
            var address = await _addressService.GetAddressById(id);

            if (address == null)
                return NotFound();

            return Ok(address);
        }

        [HttpGet]
        [Route("Type")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<EntityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressResponse>> GetAddressTypes()
        {
            var addressTypes = await _addressService.GetAddressTypes();

            if (addressTypes == null)
                return NotFound();

            return Ok(addressTypes);
        }

        [HttpPost]
        [Route("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AddressResponse>> CreateAddress([MinIntValidation] string id, AddressTypeRequest request)
        {
            if (id != request.UserId)
                return BadRequest();

            var address = await _addressService.CreateAddress(request);

            if (address == null)
                return BadRequest();

            return Ok(address);
        }

        [HttpPost]
        [Route("UserAddress/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AddressResponse>> CreateUserAddress([MinIntValidation] string id, UserAddressRequest request)
        {
            if (id != request.UserId)
                return BadRequest();

            var address = await _addressService.CreateUserAddress(request);

            if (address == null)
                return BadRequest();

            return Ok(address);
        }
    }
}
