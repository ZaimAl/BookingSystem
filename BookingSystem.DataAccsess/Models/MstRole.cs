﻿using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class MstRole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual ICollection<MstRoleMenu> MstRoleMenus { get; set; } = new List<MstRoleMenu>();

    public virtual ICollection<MstUser> MstUsers { get; set; } = new List<MstUser>();
}
