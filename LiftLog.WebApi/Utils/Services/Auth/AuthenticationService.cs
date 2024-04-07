using LiftLog.WebApi.Utils.Models.Identity;
using LiftLog.WebApi.Utils.Services.Emailing;
using Microsoft.AspNetCore.Identity;

namespace LiftLog.WebApi.Utils.Services.Auth
{
    public class AuthenticationService
    {
        private readonly JwtTokenService _jwtTokenService;
        private UserManager<User> _userManager;
        private SignInManager<User> _signinManager;

        public AuthenticationService(UserManager<User> userManager,
                                     JwtTokenService jwtTokenService,
                                     SignInManager<User> signinManager,
                                     IHostEnvironment hostEnvironment,
                                     IEmailSender emailSender)
        {
            _jwtTokenService = jwtTokenService;
            _userManager = userManager;
            _signinManager = signinManager;
            _hostEnvironment = hostEnvironment;
            _emailSender = emailSender;
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
        public async Task<(IdentityResult, User)> CreateUserAsync(RegisterRequestModel model)
        {
            var result = new IdentityResult();
            // Automap here
            var user = new User { FirstName = model.FirstName, LastName = model.LastName, UserName = model.UserName, Email = model.Email };
            try
            {
                result = await _userManager.CreateAsync(user, model.Password);
            }
            catch { }
            return (result, user);
        }
    }
}
