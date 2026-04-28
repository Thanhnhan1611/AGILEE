using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbBrand
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TbPorduct> TbPorducts { get; set; } = new List<TbPorduct>();
}
