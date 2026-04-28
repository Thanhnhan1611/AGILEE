using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbPost
{
    public int PostId { get; set; }

    public string? Name { get; set; }

    public string? SeiTitle { get; set; }

    public int? Status { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Detail { get; set; }

    public int? CateId { get; set; }

    public int? ViewCount { get; set; }

    public string? MetaKeywords { get; set; }

    public string? Metadescriptions { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TbPostCatetogy? Cate { get; set; }

    public virtual ICollection<TbPostComment> TbPostComments { get; set; } = new List<TbPostComment>();
}
