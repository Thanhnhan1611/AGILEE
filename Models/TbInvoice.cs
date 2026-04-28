using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbInvoice
{
    public int InvoiceId { get; set; }

    public string? Status { get; set; }

    public int? SupplierId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual TbSupplier? Supplier { get; set; }

    public virtual ICollection<TbInvoiceDetail> TbInvoiceDetails { get; set; } = new List<TbInvoiceDetail>();
}
