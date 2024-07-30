using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class MstMenu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Functions { get; set; } = null!;

    public int? Sequence { get; set; }

    public int? IsHeader { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual ICollection<MstRoleMenu> MstRoleMenus { get; set; } = new List<MstRoleMenu>();
}
