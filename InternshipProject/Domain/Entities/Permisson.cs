using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Permisson : BaseEntity
{

    public int? FolderId { get; set; }

    public int? FileId { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual File? File { get; set; }

    public virtual Folder? Folder { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
