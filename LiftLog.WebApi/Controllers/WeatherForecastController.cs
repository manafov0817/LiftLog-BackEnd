using LiftLog.WebApi.Utils.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace LiftLog.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
            _logger = logger;
        }

        [HttpGet]
        public string Get(string userId, string userEmail)
        {
           return _jwtTokenService.GenerateToken(userId, userEmail);    
        }
    }
}
