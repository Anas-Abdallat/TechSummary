using System;
using System.Collections.Generic;

namespace TechSummary.Models;

public partial class Content
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ContentTypeId { get; set; }

    public string Url { get; set; } = null!;

    public int? TopicId { get; set; }

    public int? UploadedBy { get; set; }

    public int? Views { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual LookupItem? ContentType { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual Topic? Topic { get; set; }

    public virtual User? UploadedByNavigation { get; set; }
}
