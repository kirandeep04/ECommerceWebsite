using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.Areas.Admin.Models
{
    public class CategoryUIViewModel
    {
   
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
