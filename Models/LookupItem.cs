using System;
using System.Collections.Generic;

namespace TechSummary.Models;

public partial class LookupItem
{
    public int Id { get; set; }

    public int? LookupTypeId { get; set; }

    public string Name { get; set; } = null!;

    public int Value { get; set; }

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();

    public virtual LookupType? LookupType { get; set; }

    public virtual ICollection<User> UserGenders { get; set; } = new List<User>();

    public virtual ICollection<User> UserRoles { get; set; } = new List<User>();
}
