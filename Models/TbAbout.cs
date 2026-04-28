using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbAbout
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public int? Status { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? MetaKeywords { get; set; }

    public string? Metadescriptions { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }
}
