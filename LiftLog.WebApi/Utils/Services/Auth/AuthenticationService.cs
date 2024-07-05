using AutoMapper;
using LiftLog.WebApi.Utils.Models.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using NLog;
using System.Net;

namespace LiftLog.WebApi.Utils.Services.Auth
{
    public class AuthenticationService
    {
        private readonly JwtTokenService _jwtTokenService;
        private UserManager<User> _userManager;
        private SignInManager<User> _signinManager;
        private readonly IMapper _mapper;
        private readonly Logger Logger = LogManager.GetLogger("AuthLogger");

        public AuthenticationService(UserManager<User> userManager,
                                     JwtTokenService jwtTokenService,
                                     SignInManager<User> signinManager,
                                     IMapper mapper,
                                     ILogger<AuthenticationService> logger)
        {
            _jwtTokenService = jwtTokenService;
            _userManager = userManager;
            _signinManager = signinManager;
            _mapper = mapper;
        }

        public async Task<(HttpResponseMessage, string)> AuthenticateUser(string userEmail, string password)
        {
            Logger.Info($"Searching user by email: {userEmail}");
            var user = await _userManager.FindByEmailAsync(userEmail);
            string notFound = "";
            if (user == null)
            {
                Logger.Info($"Searching user by username: {userEmail}");
                user = await _userManager.FindByNameAsync(userEmail);
            }

            if (user == null)
            {
                notFound = "Username or email not found";
                Logger.Info($"{notFound}: {userEmail}");
                return (new HttpResponseMessage(HttpStatusCode.NotFound), notFound);
            }

            var result = await _signinManager.PasswordSignInAsync(user, password, true, false);

            if (!result.Succeeded)
            {
                Logger.Info($"Invalid password for {userEmail}: {password.Substring(0, 3)}");
                return (new HttpResponseMessage(HttpStatusCode.NotFound), notFound);
            }

            string resToken = result.Succeeded ? _jwtTokenService.GenerateToken(user.UserName, user.Email) : null;

            Logger.Info($"Signing In User. Username: {user.UserName}, First 10 digits of token: {resToken.Substring(0, 10)}");

            return (new HttpResponseMessage(HttpStatusCode.OK), notFound);
        }
        public async Task<(IdentityResult, User)> CreateUserAsync(RegisterRequestModel model)
        {
            var result = new IdentityResult();

            var user = _mapper.Map<User>(model);
            try
            {
                Logger.Info($"Creating User: {model.ToString()}");
                result = await _userManager.CreateAsync(user, model.Password);
            }
            catch { }
            return (result, user);
        }
        public async Task<bool> ConfirmEmail(string userId, string code)
        {

            if (userId == null || code == null)
                return false;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            var result = await _userManager.ConfirmEmailAsync(user, code);
            Logger.Info($"Email confirmed for: {userId}");

            return result.Succeeded;
        }

    }
}
