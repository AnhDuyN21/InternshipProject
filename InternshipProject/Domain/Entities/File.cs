using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class File : BaseEntity
{

    public string Name { get; set; } = null!;

    public int FolderId { get; set; }

    public string FileType { get; set; } = null!;

    public virtual Folder Folder { get; set; } = null!;

    public virtual ICollection<Permisson> Permissons { get; set; } = new List<Permisson>();
}
