using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class TrsParticipant
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public string Email { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public bool IsVip { get; set; }
}
