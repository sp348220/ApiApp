using System;
using System.Collections.Generic;

namespace CrudByApi.Models;

public partial class AppUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int DeparmentId { get; set; }

    public virtual ICollection<AppUserRole> AppUserRoles { get; set; } = new List<AppUserRole>();

    public virtual Department Deparment { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
