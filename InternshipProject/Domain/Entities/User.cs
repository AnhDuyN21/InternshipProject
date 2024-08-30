using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User : BaseEntity
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Permisson> Permissons { get; set; } = new List<Permisson>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UsersDrive> UsersDrives { get; set; } = new List<UsersDrive>();
}
