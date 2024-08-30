using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UsersDrive : BaseEntity
{

    public int UserId { get; set; }

    public int DriveId { get; set; }

    public virtual Drive Drive { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
