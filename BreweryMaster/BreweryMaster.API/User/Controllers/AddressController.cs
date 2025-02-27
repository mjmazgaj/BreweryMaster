using BreweryMaster.API.SharedModule.Validators;
using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.User.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.User.Controllers
{
    public class AddressController : Controller
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
    }
}
