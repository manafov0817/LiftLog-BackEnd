using AutoMapper;
using LiftLog.Business.Abstract;
using LiftLog.Entity.Models;
using LiftLog.WebApi.Utils.Models.Identity;
using Microsoft.AspNetCore.Identity;
using NLog;
using System.Net;
using System.Security.Claims;

namespace LiftLog.WebApi.Utils.Services.Auth
{
    public class AuthenticationService
    {
        private UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly Logger Logger = LogManager.GetLogger("AuthLogger");
        private readonly IConfiguration _configuration;
        private readonly IUserProfileService _userProfileService;
        private readonly JwtTokenService _jwtTokenService;

        public AuthenticationService(UserManager<User> userManager,
                                     IMapper mapper,
                                     IConfiguration configuration,
                                     IUserProfileService userProfileService,
                                     JwtTokenService jwtTokenService
                                     )
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _userProfileService = userProfileService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<(HttpResponseMessage, string)> AuthenticateUser(string userEmail, string password)
        {
            Logger.Info($"Searching user by email: {userEmail}");
            var user = await _userManager.FindByEmailAsync(userEmail);
            string notFound = "Username or password not found";
            if (user == null)
            {
                Logger.Info($"Searching user by username: {userEmail}");
                user = await _userManager.FindByNameAsync(userEmail);
            }

            if (user == null)
            {
                Logger.Info($"{notFound}: {userEmail}");
                return (new HttpResponseMessage(HttpStatusCode.NotFound), notFound);
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                ClaimsIdentity claimsIdentity = await GetClaims(user);

                string tokenString = _jwtTokenService.GenerateToken(claimsIdentity);

                Logger.Info($"Signing In User. Username: {user.UserName}, First 10 digits of token: {tokenString.Substring(0, 10)}");

                return (new HttpResponseMessage(HttpStatusCode.OK), tokenString);
            }

            return (new HttpResponseMessage(HttpStatusCode.BadRequest), notFound);
        }

        private async Task<ClaimsIdentity> GetClaims(User? user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserRole", "User")
                });

            try
            {
                var userProfile = await _userProfileService.GetByUserIdAsync(Guid.Parse(user.Id));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userProfile.Id.ToString()));
            }
            catch (Exception ex) { }

            var userClaims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in userClaims) claimsIdentity.AddClaim(claim);
            return claimsIdentity;
        }

        public async Task<(IdentityResult, User)> CreateUserAsync(RegisterRequestModel model)
        {
            var result = new IdentityResult();

            var user = _mapper.Map<User>(model);
            try
            {
                Logger.Info($"Creating User: {model.ToString()}");
                result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Add claims to the user
                    await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));

                    var createdUser = await _userManager.FindByEmailAsync(model.Email);

                    if (createdUser is not null)
                    {
                        UserProfile profile = _mapper.Map<UserProfile>(model);
                        profile.UserId = createdUser?.Id;
                        await _userProfileService.CreateAsync(profile);
                    }
                }
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
        public (string LogoutMessage, bool IsSucceeded) Logout(string token)
        {
            if (token == null)
                return ("Token is required", false);
            return ("Logged out successfully", true);
        }
    }
}
