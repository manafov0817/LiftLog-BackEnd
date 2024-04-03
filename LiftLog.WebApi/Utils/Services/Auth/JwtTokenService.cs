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

        public string GenerateToken(string userName, string userEmail)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_secretKey));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(ClaimTypes.Email, userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            JwtSecurityToken token = new JwtSecurityToken(_issuer,
                                                          _audience,
                                                          claims,
                                                          DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                                                          signingCredentials: credentials);

            string res = new JwtSecurityTokenHandler().WriteToken(token);

            return res;
        }
    }
}
