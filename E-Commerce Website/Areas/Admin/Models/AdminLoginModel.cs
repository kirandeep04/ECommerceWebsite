using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.Areas.Admin.Models
{
    public class AdminLoginModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is necessary")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is necessary")]
        public string? Password { get; set; }
    }
}

