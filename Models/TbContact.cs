using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbContact
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public string? Status { get; set; }
}
