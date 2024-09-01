using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LiftLog.WebApi.Utils.Services.Auth
{
    public class JwtTokenService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiryInMinutes;

        public JwtTokenService(string SecretKey, string Issuer, string audience, int expiryInMinutes)
        {
            _secretKey = SecretKey;
            _issuer = Issuer;
            _audience = audience;
            _expiryInMinutes = expiryInMinutes;
        }

        public string GenerateToken(ClaimsIdentity claimsIdentity)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_secretKey));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityTokenHandler tokenHandler = new();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _issuer,
                Audience = _audience,               
            };

            var tokenItself = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(tokenItself);
            return tokenString;
        }
    }
}
