using System;
using System.Collections.Generic;

namespace CrudByApi.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Definition { get; set; } = null!;

    public virtual ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();
}
