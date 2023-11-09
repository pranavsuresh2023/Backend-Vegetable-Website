using System;
using System.Collections.Generic;

namespace AssignmentProject.Models;

public partial class Vegetable
{
    public int VegId { get; set; }

    public int? UserId { get; set; }

    public string? VegName { get; set; }

    public virtual UserDetail? User { get; set; }
}
