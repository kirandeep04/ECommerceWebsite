using System;
using System.Collections.Generic;

namespace E_Commerce_Website.API.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RolesId { get; set; }

    public virtual Role? Roles { get; set; }

    public virtual UserLogin? User { get; set; }
}
