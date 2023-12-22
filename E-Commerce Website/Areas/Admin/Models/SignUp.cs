using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.Areas.Admin.Models
{
    public class SignUp
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is necessary")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is necessary")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is necessary")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Password is necessary")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Country is necessary")]
        public string? Country{ get; set; }
        [Required(ErrorMessage = "Address is necessary")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "City is necessary")]
        public string? City { get; set; }
        [Required(ErrorMessage = "State is necessary")]
        public string? State { get; set; }
    
    }
}
