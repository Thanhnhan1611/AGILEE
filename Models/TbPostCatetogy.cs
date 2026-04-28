using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbPostCatetogy
{
    public int CateId { get; set; }

    public string? Name { get; set; }

    public string? Seotitle { get; set; }

    public int? Status { get; set; }

    public int? Sort { get; set; }

    public int? ParentId { get; set; }

    public string? MetaKeywords { get; set; }

    public string? Metadescriptions { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TbPost> TbPosts { get; set; } = new List<TbPost>();
}
