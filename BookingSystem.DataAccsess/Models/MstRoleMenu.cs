﻿using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class MstRoleMenu
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int MenuId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public virtual MstMenu Menu { get; set; } = null!;

    public virtual MstRole Role { get; set; } = null!;
}
