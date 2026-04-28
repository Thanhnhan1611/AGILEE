using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbTag
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<TbPostTag> TbPostTags { get; set; } = new List<TbPostTag>();
}
