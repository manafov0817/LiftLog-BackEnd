namespace LiftLog.WebApi.Utils.Services.Auth
{
    public class AuthenticationService
    {
        private readonly JwtTokenService _jwtTokenService;
        public AuthenticationService(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> AuthenticateUser(string userId, string userEmail)
        {
            // Authentication logic here...

            // If user is authenticated, generate token
            string token = _jwtTokenService.GenerateToken(userId, userEmail);
            return token;
        }
    }
}
