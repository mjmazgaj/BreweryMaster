using BreweryMaster.API.User.Models;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.User.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.User.Controllers
{
    public class AddressController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAddressService _addressService;

        public AddressController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IAddressService addressService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _addressService = addressService;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressResponse?>> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressById(id);

            if (address == null)
                return NotFound();

            return Ok(address);
        }
    }
}
