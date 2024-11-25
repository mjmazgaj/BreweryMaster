using BreweryMaster.API.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BreweryMaster.API.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (request.Password != request.ConfirmPassword)
                return BadRequest(new { message = "Passwords do not match." });

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                TestBool = request.TestBool
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "User registered successfully." });
        }

        [HttpGet]
        [Route("info")]
        public IActionResult GetInfo()
        {
            var user = HttpContext.User;

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                var emailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                var nameIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                return Ok(new
                {
                    Id = nameIdClaim?.Value,
                    Email = emailClaim?.Value
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync();

            return Ok();
        }
    }
}
