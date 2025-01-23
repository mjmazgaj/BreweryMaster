using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.User.Services;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<UserResponse>?>> GetUsers()
        {
            var users = await _userService.GetUsers();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserResponse?>> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
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

            if (request.Password != request.ConfirmPassword)
                return BadRequest(new { message = "Passwords do not match." });

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

        [HttpGet]
        [Route("currentUserRoles")]
        public async Task<ActionResult<IEnumerable<string>>> GetCurrentUserRoles()
        {
            var userContext = HttpContext.User;

            try
            {
                var roles = await _userService.GetCurrentUserRoles(userContext);

                return Ok(roles);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("info")]
        public IActionResult GetInfo()
        {
            var userContext = HttpContext.User;

            try
            {
                var user = _userService.GetCurrentUser(userContext);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
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
