using LiftLog.WebApi.Utils.Models.Identity;
using LiftLog.WebApi.Utils.Services.Auth;
using LiftLog.WebApi.Utils.Services.Emailing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LiftLog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly IEmailSender _emailSender;
        public AuthController(AuthenticationService authenticationService, IEmailSender emailSender)
        {
            _authenticationService = authenticationService;
            _emailSender = emailSender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            (HttpResponseMessage resp, string tokenOrError) = await _authenticationService.AuthenticateUser(model.Email, model.Password);

            if (!resp.IsSuccessStatusCode)
                return Unauthorized(tokenOrError);

            var dat = Ok(new { Token = tokenOrError });

            return dat;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            (IdentityResult result, User user) = await _authenticationService.CreateUserAsync(model);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!await _emailSender.SendConfirmationEmailAsync(HttpContext.Request, user))
                return BadRequest("Error while sending email");

            return Ok("User Successfully Created!");
        }

        [HttpGet("confirmEmail")]
        public async Task<HttpResponseMessage> ConfirmEmail(string userId, string code)
        {
            bool res = await _authenticationService.ConfirmEmail(userId, code);
            return new HttpResponseMessage(res ? HttpStatusCode.Accepted : HttpStatusCode.NotFound);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            string token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var res = _authenticationService.Logout(token);

            return res.IsSucceeded ? Ok(res.LogoutMessage) : BadRequest(res.LogoutMessage);
        }
    }
}
