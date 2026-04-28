using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbConfig
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Type { get; set; }

    public string? Value { get; set; }

    public int? Status { get; set; }
}
