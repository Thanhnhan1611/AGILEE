using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbOrderDetail
{
    public int OderId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quanlity { get; set; }

    public virtual TbOrder Oder { get; set; } = null!;

    public virtual TbPorduct Product { get; set; } = null!;
    public int Quantity { get; internal set; }
}
