using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbProductComment
{
    public int CommentId { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public string? Email { get; set; }

    public int? ProductId { get; set; }

    public int? Status { get; set; }

    public int? UpdatedBy { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Rating { get; set; }

    public int? CustomerId { get; set; }

    public virtual TbCustomer? Customer { get; set; }

    public virtual TbPorduct? Product { get; set; }
}
