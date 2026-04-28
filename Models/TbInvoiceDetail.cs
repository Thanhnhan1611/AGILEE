using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbInvoiceDetail
{
    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Quanlity { get; set; }

    public decimal? Price { get; set; }

    public virtual TbInvoice Invoice { get; set; } = null!;

    public virtual TbPorduct Product { get; set; } = null!;
}
