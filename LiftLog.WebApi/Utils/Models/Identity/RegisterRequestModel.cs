using Microsoft.AspNetCore.Identity;

namespace LiftLog.WebApi.Utils.Models.Identity
{
    public class RegisterRequestModel  
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
