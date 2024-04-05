using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LiftLog.WebApi.Utils.Models.Identity
{
    public class RegisterRequestModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Password Confirm is required")]
        public string PasswordConfirm { get; set; }
    }
}
