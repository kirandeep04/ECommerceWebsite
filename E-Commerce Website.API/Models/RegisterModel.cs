using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is necessary")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is necessary")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Password is necessary")]
        public string? Password { get; set; }
    }
}
