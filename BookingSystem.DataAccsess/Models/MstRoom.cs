using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class MstRoom
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Capasity { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public string? RoomColor { get; set; }

    public int? LocationId { get; set; }

    public int? Floor { get; set; }

    public virtual MstLocation? Location { get; set; }

    public virtual ICollection<MstRoomResource> MstRoomResources { get; set; } = new List<MstRoomResource>();

    public virtual ICollection<TrsBooking> TrsBookings { get; set; } = new List<TrsBooking>();
}
