using System;
using System.Collections.Generic;

namespace CrudByApi.Models;

public partial class AppRole
{
    public int Id { get; set; }

    public string Definition { get; set; } = null!;

    public virtual ICollection<AppUserRole> AppUserRoles { get; set; } = new List<AppUserRole>();
}
