using System;
using System.Collections.Generic;

namespace TechSummary.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? GenderId { get; set; }

    public int? RoleId { get; set; }

    public int? Age { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();

    public virtual LookupItem? Gender { get; set; }

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual LookupItem? Role { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();


}
