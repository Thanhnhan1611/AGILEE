using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbFooter
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public int? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
