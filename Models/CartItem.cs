namespace WebBanHang.Models
{
    public class CartItem
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; } = string.Empty;
        public string? Hinh { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => SoLuong * DonGia;
    }
}