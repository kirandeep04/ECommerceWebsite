namespace E_Commerce_Website.API.Models;

public partial class Role
{
    public int Rolesid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
