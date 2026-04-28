using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbPasswordReset
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? Token { get; set; }

    public string? ExprireData { get; set; }
}
