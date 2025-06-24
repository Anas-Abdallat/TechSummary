using System;
using System.Collections.Generic;

namespace TechSummary.Models;

public partial class LookupType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<LookupItem> LookupItems { get; set; } = new List<LookupItem>();
}
