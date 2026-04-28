using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbPorduct
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? SeiTitle { get; set; }

    public int? Status { get; set; }

    public decimal? Price { get; set; }

    public int? Quanlity { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public int? CateId { get; set; }

    public int? BrainId { get; set; }

    public int? SupplierId { get; set; }

    public int? ViewCount { get; set; }

    public string? MetaKeywords { get; set; }

    public string? Metadescriptions { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Image { get; set; }

    public virtual TbBrand? Brain { get; set; }

    public virtual TbProductCategory? Cate { get; set; }

    public virtual TbSupplier? Supplier { get; set; }

    public virtual ICollection<TbInvoiceDetail> TbInvoiceDetails { get; set; } = new List<TbInvoiceDetail>();

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();

    public virtual ICollection<TbProductComment> TbProductComments { get; set; } = new List<TbProductComment>();
}
