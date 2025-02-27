using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.User.Models.Responses;
using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;
using BreweryMaster.API.User.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [Authorize(Roles = "manager")]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers([FromQuery] UserFilterRequest? request)
        {
            var users = await _userService.GetUsers(request);

            return Ok(users);
        }

        [HttpGet]
        [Route("DropDown")]
        [Authorize(Roles = "employee")]
        [ProducesResponseType(typeof(IEnumerable<EntityStringIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<EntityStringIdResponse>>> GetUserDropDownList()
        {
            var users = await _userService.GetUserDropDownList();

            return Ok(users);
        }

        [HttpGet]
        [Route("Role")]
        [Authorize(Roles = "manager")]
        [ProducesResponseType(typeof(IEnumerable<EntityStringIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<EntityStringIdResponse>>> GetRolesDropDownList()
        {
            var users = await _userService.GetRolesDropDownList();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "manager")]
        [ProducesResponseType(typeof(UserDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailsResponse>> GetUserById([MaxLength(450)] string id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserResponse>> Register(UserRegisterRequest request)
        {
            if (request.UserAuthInfo.Password != request.UserAuthInfo.ConfirmPassword)
                return BadRequest("Password and ConfirmPassword dosen't match");

            var createdUser = await _userService.CreateUser(request);

            if (createdUser is null)
                return BadRequest();

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPatch]
        [Route("{userId}")]
        [Authorize]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserResponse>> Update(UserUpdateRequest request, [MaxLength(450)] string userId)
        {
            if (request.Id != userId)
                return BadRequest();

            var updatedUser = await _userService.UpdateUser(request, userId);

            if (updatedUser is null)
                return BadRequest();

            return Ok(updatedUser);
        }

        [HttpPatch]
        [Route("Password")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> UpdatePassword(UserPasswordRequest request)
        {
            var userIdentity = HttpContext?.User?.Identity;

            if (userIdentity is null || !userIdentity.IsAuthenticated)
                return Unauthorized();

            if (request.Password != request.ConfirmPassword)
                return BadRequest("Password and ConfirmPassword dosen't match");

            var result = await _userService.UpdatePassword(request, HttpContext?.User);

            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch]
        [Route("Roles/{id}")]
        [Authorize(Roles = "manager")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<bool>> UpdateUserRoles(UserRolesUpdateRequest request, [MaxLength(450)] string id)
        {
            if (request.UserId != id)
                return BadRequest();

            var result = await _userService.UpdateUserRoles(request);

            if (!result)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("Info")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserResponse>> GetInfo()
        {
            var userIdentity = HttpContext?.User?.Identity;

            if (userIdentity is null || !userIdentity.IsAuthenticated)
                return Unauthorized();

            var curretUser = await _userService.GetCurrentUser(HttpContext?.User);

            return Ok(curretUser);
        }

        [HttpGet]
        [Route("Details")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDetailsResponse>> GetUserDetails()
        {
            var userIdentity = HttpContext?.User?.Identity;

            if (userIdentity is null || !userIdentity.IsAuthenticated)
                return Unauthorized();

            var userDetails = await _userService.GetCurrentUserDetails(HttpContext?.User);

            return Ok(userDetails);
        }

        [HttpPost]
        [Route("Logout")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync();

            return Ok();
        }

        [HttpPost]
        [Route("AddTestUsers")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> AddTestUsers()
        {
            var result = await _userService.CreateTestUsers();

            if (!result)
                return BadRequest();

            return Ok(result);
        }
    }
}
