using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.Models
{
    public class LoginAPIModel
    {

        [Required(ErrorMessage = "Username is necessary")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is necessary")]
        public string? Password { get; set; }
    }
}
