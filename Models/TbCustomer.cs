using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models;

[Table("tb_Customer")]
public partial class TbCustomer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? Status { get; set; }
    public int? RoleId { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
    public virtual ICollection<TbProductComment> TbProductComments { get; set; } = new List<TbProductComment>();
}