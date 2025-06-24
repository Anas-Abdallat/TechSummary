using System;
using System.Collections.Generic;

namespace TechSummary.Models;

public partial class Topic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? LanguageId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Language? Language { get; set; }
}
