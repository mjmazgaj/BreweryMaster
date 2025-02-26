using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.User.Models.Responses;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.User.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BreweryMaster.API.UserModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserResponse>?>> GetUsers([FromQuery] UserFilterRequest? request)
        {
            var users = await _userService.GetUsers(request);

            return Ok(users);
        }

        [HttpGet]
        [Route("DropDown")]
        [ProducesResponseType(typeof(IEnumerable<EntityStringIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityStringIdResponse>?>> GetUserDropDownList()
        {
            var users = await _userService.GetUserDropDownList();

            return Ok(users);
        }

        [HttpGet]
        [Route("Role")]
        [ProducesResponseType(typeof(IEnumerable<EntityStringIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EntityStringIdResponse>?>> GetRolesDropDownList()
        {
            var users = await _userService.GetRolesDropDownList();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(UserDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailsResponse?>> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (request.UserAuthInfo.Password != request.UserAuthInfo.ConfirmPassword)
                return BadRequest(new { message = "Passwords do not match." });

            try
            {
                var createdUser = await _userService.CreateUser(request);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception)
            {
                return UnprocessableEntity($"{request.UserAuthInfo.Email} registration faild");
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateRequest request, string userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _userService.UpdateUser(request, userId);
            }
            catch (Exception)
            {
                return BadRequest("User not updated");
            }

            return Ok(new { message = "User updated successfully." });
        }

        [HttpPatch]
        [Route("Password")]
        public async Task<IActionResult> UpdatePassword(UserPasswordRequest request)
        {
            var result = await _userService.UpdatePassword(request, HttpContext.User);

            if (!result)
                BadRequest(result);

            return Ok(result);
        }

        [HttpPatch]
        [Route("Roles/{id}")]
        public async Task<IActionResult> UpdateUserRoles(UserRolesUpdateRequest request, string id)
        {
            var result = await _userService.UpdateUserRoles(request);

            if (!result)
                BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("info")]
        public async Task<ActionResult<UserResponse?>> GetInfo()
        {
            var userContext = HttpContext.User;

            try
            {
                var user = await _userService.GetCurrentUser(userContext);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<UserDetailsResponse>> GetUserDetails()
        {
            var userContext = HttpContext.User;

            var user = await _userService.GetCurrentUserDetails(userContext);
            return Ok(user);
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync();

            return Ok();
        }

        [HttpPost]
        [Route("addTestUsers")]
        public async Task<ActionResult> AddTestUsers()
        {
            var result = await _userService.CreateTestUsers();
            return Ok(result);
        }
    }
}
