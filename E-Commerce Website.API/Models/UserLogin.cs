namespace E_Commerce_Website.API.Models;

public partial class UserLogin
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Createdon { get; set; }

    public DateTime Updatedon { get; set; }

    public bool Isactive { get; set; }

    public virtual ICollection<Category> CategoryCreatedbyNavigations { get; set; } = new List<Category>();

    public virtual ICollection<Category> CategoryUpdatedbyNavigations { get; set; } = new List<Category>();

    public virtual ICollection<Product> ProductCreatedbyNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductUpdatedbyNavigations { get; set; } = new List<Product>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
