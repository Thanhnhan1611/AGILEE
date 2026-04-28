namespace WebBanHang.Models
{
    public class Order
    {
        // Tên phải khớp chính xác từng chữ hoa/thường với View
        public int OrderID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;

        public List<OrderDetailItem> Products { get; set; } = new List<OrderDetailItem>();

        // Thuộc tính này dùng để hiện tổng tiền ở Index
        public decimal TotalAmount => Products.Sum(x => x.Price * x.Quantity);
    }

    public class OrderDetailItem
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}