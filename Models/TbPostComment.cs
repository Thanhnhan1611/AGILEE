using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbPostComment
{
    public int CommentId { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public string? Email { get; set; }

    public int? Status { get; set; }

    public int? PostId { get; set; }

    public int? UpdatedBy { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TbPost? Post { get; set; }
}
