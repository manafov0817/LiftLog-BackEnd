using LiftLog.WebApi.Utils.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace LiftLog.WebApi.Utils.Services.Auth
{
    public class AuthenticationService
    {
        private readonly JwtTokenService _jwtTokenService;
        private UserManager<User> _userManager;
        private SignInManager<User> _signinManager;

        public AuthenticationService(UserManager<User> userManager, JwtTokenService jwtTokenService, SignInManager<User> signinManager)
        {
            _jwtTokenService = jwtTokenService;
            _userManager = userManager;
            _signinManager = signinManager;
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
            return result;
        }
    }
}
