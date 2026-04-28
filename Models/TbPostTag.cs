using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbPostTag
{
    public string PostId { get; set; } = null!;

    public string TagId { get; set; } = null!;

    public virtual TbTag Tag { get; set; } = null!;
}
