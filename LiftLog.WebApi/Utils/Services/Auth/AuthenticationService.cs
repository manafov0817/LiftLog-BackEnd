using LiftLog.WebApi.Utils.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Asn1.Ocsp;
using System;

namespace LiftLog.WebApi.Utils.Services.Auth
{
    public class AuthenticationService
    {
        private readonly JwtTokenService _jwtTokenService;
        private UserManager<User> _userManager;
        private SignInManager<User> _signinManager;
        IHostEnvironment _hostEnvironment;
        public AuthenticationService(UserManager<User> userManager,
                                     JwtTokenService jwtTokenService,
                                     SignInManager<User> signinManager,
                                     IHostEnvironment hostEnvironment)
        {
            _jwtTokenService = jwtTokenService;
            _userManager = userManager;
            _signinManager = signinManager;
            _hostEnvironment = hostEnvironment;

        }

        public async Task<string?> AuthenticateUser(string userEmail, string password)
        {
            // Authentication logic here...

            var user = await _userManager.FindByNameAsync(userEmail);

            if (user == null)
                user = await _userManager.FindByEmailAsync(userEmail);

            if (user == null)
                return null;

            //if (!await _userManager.IsEmailConfirmedAsync(user))
            //{
            //    return null;
            //}

            var result = await _signinManager.PasswordSignInAsync(user, password, true, false);

            return result.Succeeded ? _jwtTokenService.GenerateToken(user.UserName, user.Email) : null;
        }
        public async Task<IdentityResult> CreateUserAsync(RegisterRequestModel model)
        {
            var user = new User { FirstName = model.FirstName, LastName = model.LastName, UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                string emailContent = await CreateConfirmEmailBodyAsync(user);
            }

            return result;
        }

        public async Task<string> CreateConfirmEmailBodyAsync(User user)
        {
            // Read the HTML content from the file
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "confirmation_email_template.html");
            string emailContent = await System.IO.File.ReadAllTextAsync(filePath);

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var userId = user.Id;
            var token = code;

            var confirmationUrl = $"{ }://{}/Auth/ConfirmEmail?userId={userId}&token={token}";
            var url = Url.Action("ConfirmEmail", "Account", new
            {
                userId = user.Id,
                token = code,
            });

            return "";
        }
    }
}
