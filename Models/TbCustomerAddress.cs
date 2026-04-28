using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TbCustomerAddress
{
    public int AddressId { get; set; }

    public int CustomerId { get; set; }

    public string? ReceiverName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? IsDefault { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
