using LiftLog.WebApi.Utils.Models.Identity;
using LiftLog.WebApi.Utils.Services.Auth;
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

        public AuthController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string token = await _authenticationService.AuthenticateUser(model.Email, model.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IdentityResult result = await _authenticationService.CreateUserAsync(model);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            string token = await _authenticationService.AuthenticateUser(model.Email, model.Password);

            return Ok(new { Token = token });
        }


    }
}
