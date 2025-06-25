using System;
using System.Collections.Generic;

namespace TechSummary.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public string Image { get; set; }

    public int? CategoryId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
