using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class TrsResource
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int ResCodeId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public virtual TrsBooking Book { get; set; } = null!;

    public virtual MstResourceCode ResCode { get; set; } = null!;
}
