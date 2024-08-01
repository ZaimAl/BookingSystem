using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class TrsBooking
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string Necessity { get; set; } = null!;

    public string RequestBy { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly TimeFrom { get; set; }

    public string EmailPic { get; set; } = null!;

    public bool IsAllDay { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CancelledDate { get; set; }

    public int? CancelledBy { get; set; }

    public bool? IsRecurring { get; set; }

    public string? RecurringPattern { get; set; }

    public int? BookCodeId { get; set; }

    public string? Status { get; set; }

    public TimeOnly? TimeTo { get; set; }

    public virtual MstBookCode? BookCode { get; set; }

    public virtual MstRoom Room { get; set; } = null!;

    public virtual ICollection<TrsResource> TrsResources { get; set; } = new List<TrsResource>();
}
