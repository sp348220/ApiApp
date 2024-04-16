using System;
using System.Collections.Generic;

namespace CrudByApi.Models;

public partial class AppUserRole
{
    public int Id { get; set; }

    public int AppUserId { get; set; }

    public int AppRoleId { get; set; }

    public virtual AppRole AppRole { get; set; } = null!;

    public virtual AppUser AppUser { get; set; } = null!;
}
