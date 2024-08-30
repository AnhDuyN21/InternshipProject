using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Drive : BaseEntity
{

    public string Name { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();

    public virtual ICollection<UsersDrive> UsersDrives { get; set; } = new List<UsersDrive>();
}
