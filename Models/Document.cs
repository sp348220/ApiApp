using System;
using System.Collections.Generic;

namespace CrudByApi.Models;

public partial class Document
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string TypeOfDoc { get; set; } = null!;

    public string ClassOfDoc { get; set; } = null!;

    public string? SenderName { get; set; }

    public string? ReceiverName { get; set; }

    public int DocState { get; set; }

    public int DocStatus { get; set; }

    public int? ReplyDocId { get; set; }

    public DateTime SendDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ReceiveDate { get; set; }

    public string? RoomNumber { get; set; }

    public string? ShelfNumber { get; set; }

    public bool IsBorrowed { get; set; }

    public string? BorrowerName { get; set; }

    public int AppUserId { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;
}
