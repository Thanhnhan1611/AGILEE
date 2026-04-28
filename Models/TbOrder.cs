using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models;

public partial class TbOrder
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 🔥 AUTO INCREMENT
    public int OrderId { get; set; }

    public DateTime? Orderdate { get; set; }

    public int? Status { get; set; }

    public int? Delivered { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public int? CustomerId { get; set; }

    public int? Discount { get; set; }

    public int? VoucherId { get; set; }

    public int? AddressId { get; set; }

    public virtual TbCustomerAddress? Address { get; set; }

    public virtual TbCustomer? Customer { get; set; }

    public virtual ICollection<TbOrderDetail> TbOrderDetails { get; set; } = new List<TbOrderDetail>();

    public virtual TbVoucher? Voucher { get; set; }
}