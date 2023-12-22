namespace E_Commerce_Website.API.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Rolesid { get; set; }

    public virtual Role Roles { get; set; } = null!;

    public virtual UserLogin User { get; set; } = null!;
}
