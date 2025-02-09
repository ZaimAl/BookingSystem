﻿using System;
using System.Collections.Generic;

namespace BookingSystem.DataAccsess.Models;

public partial class MstResourceCode
{
    public int Id { get; set; }

    public int ResourceId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? DelDate { get; set; }

    public int? DelBy { get; set; }

    public string? ResourceCode { get; set; }

    public virtual MstResource Resource { get; set; } = null!;

    public virtual ICollection<TrsResource> TrsResources { get; set; } = new List<TrsResource>();
}
