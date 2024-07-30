using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class MstLocation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual ICollection<MstRoom> MstRooms { get; set; } = new List<MstRoom>();
}
