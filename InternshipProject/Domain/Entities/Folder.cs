using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Folder : BaseEntity
{

    public string Name { get; set; } = null!;

    public int? ParentFolder { get; set; }

    public int? SubFolder { get; set; }

    public int DriveId { get; set; }

    public virtual Drive Drive { get; set; } = null!;

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual ICollection<Permisson> Permissons { get; set; } = new List<Permisson>();
}
