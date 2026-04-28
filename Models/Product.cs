namespace WebBanHang.Models
{
    public class Product
    {
        public int ProductID { get; set; }      // Mã sản phẩm
        public string Name { get; set; }        // Tên sản phẩm
        public string Description { get; set; } // Mô tả chi tiết
        public decimal Price { get; set; }      // Giá bán
        public string Image { get; set; }       // Tên file ảnh (ví dụ: sp1.jpg)
        public string Category { get; set; }    // Danh mục (Điện thoại, Áo...)
    }
}