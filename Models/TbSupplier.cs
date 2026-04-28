using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbSupplier
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<TbInvoice> TbInvoices { get; set; } = new List<TbInvoice>();

    public virtual ICollection<TbPorduct> TbPorducts { get; set; } = new List<TbPorduct>();
}
