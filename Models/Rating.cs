using System;
using System.Collections.Generic;

namespace TechSummary.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int? ContentId { get; set; }

    public int? UserId { get; set; }

    public int? RateAmount { get; set; }

    public string? Message { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Content? Content { get; set; }

    public virtual User? User { get; set; }
}
