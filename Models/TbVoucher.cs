using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbVoucher
{
    public int VoucherId { get; set; }

    public string? Code { get; set; }

    public decimal? DiscountPercent { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? Quanlity { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
