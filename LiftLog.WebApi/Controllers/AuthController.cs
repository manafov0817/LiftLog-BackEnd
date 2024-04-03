using LiftLog.WebApi.Utils.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(AuthenticationService authenticationService, UserManager<IdentityUser> userManager)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var user = new User { FirstName = model.FirstName, LastName = model.LastName, UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(model, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Automatically sign in the user after registration (optional)
            //string token = await _authenticationService.AuthenticateUserAsync(model.Email, model.Password);

            return Ok(/*new { Token = token }*/);

        }

    }
}
