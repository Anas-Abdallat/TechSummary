using System;
using System.Collections.Generic;

namespace TechSummary.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();
}
