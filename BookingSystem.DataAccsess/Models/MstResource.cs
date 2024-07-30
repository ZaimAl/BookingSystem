using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class MstResource
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public string Icon { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual ICollection<MstResourceCode> MstResourceCodes { get; set; } = new List<MstResourceCode>();

    public virtual ICollection<MstRoomResource> MstRoomResources { get; set; } = new List<MstRoomResource>();
}
