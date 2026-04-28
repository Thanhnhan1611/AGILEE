using WebBanHang.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using BCrypt.Net;

namespace WebBanHang.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebBanHangContext context)
        {
            context.Database.EnsureCreated();

            // --- 1. TẠO TÀI KHOẢN ADMIN MẶC ĐỊNH ---
            if (!context.TbCustomers.Any(c => c.Email == "admin@gmail.com"))
            {
                var adminAccount = new TbCustomer
                {
                    Name = "Quản trị viên",
                    Email = "admin@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Status = 1,
                    RoleId = 1
                };
                context.TbCustomers.Add(adminAccount);
                context.SaveChanges();
            }

            // --- 2. CHỈ SEED SẢN PHẨM KHI CHƯA CÓ DỮ LIỆU ---
            // ✅ FIX: Không xóa và tạo lại mỗi lần → tránh lỗi UNIQUE constraint
            if (context.TbProductCategories.Any() && context.TbPorducts.Any())
            {
                return; // Đã có dữ liệu rồi, không làm gì thêm
            }

            // --- 3. NẠP DANH MỤC ---
            if (!context.TbProductCategories.Any())
            {
                var categories = new List<TbProductCategory>
                {
                    new TbProductCategory { CateId = 1, Name = "Điện thoại", Status = 1, CreatedDate = DateTime.Now },
                    new TbProductCategory { CateId = 2, Name = "Laptop", Status = 1, CreatedDate = DateTime.Now }
                };
                context.TbProductCategories.AddRange(categories);
                context.SaveChanges();
            }

            // --- 4. NẠP SẢN PHẨM ---
            if (!context.TbPorducts.Any())
            {
                var products = new List<TbPorduct>
                {
                    // --- ĐIỆN THOẠI (CateId = 1) ---
                    new TbPorduct {
                        ProductId = 1, Name = "iPhone 15 Pro", CateId = 1, Price = 28000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://m.media-amazon.com/images/I/81+GIkwqLIL._AC_SL1500_.jpg",
                        Description = "Điện thoại Apple iPhone 15 Pro cao cấp vỏ Titanium mượt mà.",
                        Detail = "<strong>Màn hình:</strong> 6.1 inch, Super Retina XDR OLED, 120Hz<br/>" +
                                 "<strong>Hệ điều hành:</strong> iOS 17<br/>" +
                                 "<strong>Chip xử lý (CPU):</strong> Apple A17 Pro 6 nhân<br/>" +
                                 "<strong>RAM:</strong> 8 GB | <strong>ROM:</strong> 256 GB<br/>" +
                                 "<strong>Camera:</strong> Chính 48 MP & Phụ 12 MP, 12 MP<br/>" +
                                 "<strong>Pin:</strong> 3274 mAh, Sạc nhanh 20W<br/>" +
                                 "<strong>Đặc biệt:</strong> Khung viền Titanium chuẩn hàng không vũ trụ."
                    },
                    new TbPorduct {
                        ProductId = 2, Name = "Samsung S24 Ultra", CateId = 1, Price = 26000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1610945415295-d9bbf067e59c?q=80&w=500",
                        Description = "Điện thoại Samsung Galaxy S24 Ultra tích hợp trí tuệ nhân tạo AI và bút S-Pen.",
                        Detail = "<strong>Màn hình:</strong> 6.8 inch, Dynamic AMOLED 2X, 2K+<br/>" +
                                 "<strong>Hệ điều hành:</strong> Android 14 (One UI 6.1)<br/>" +
                                 "<strong>Chip xử lý (CPU):</strong> Snapdragon 8 Gen 3 For Galaxy<br/>" +
                                 "<strong>RAM:</strong> 12 GB | <strong>ROM:</strong> 256 GB<br/>" +
                                 "<strong>Camera:</strong> Chính 200 MP & Phụ 50 MP, 12 MP, 10 MP<br/>" +
                                 "<strong>Pin:</strong> 5000 mAh, Sạc siêu nhanh 45W<br/>" +
                                 "<strong>Đặc biệt:</strong> Tích hợp bút S-Pen, Trí tuệ nhân tạo Galaxy AI."
                    },
                    new TbPorduct {
                        ProductId = 3, Name = "Xiaomi 14 Pro", CateId = 1, Price = 20000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1598327105666-5b89351aff97?q=80&w=500",
                        Description = "Điện thoại Xiaomi 14 Pro chụp ảnh siêu nét với ống kính Leica.",
                        Detail = "<strong>Màn hình:</strong> 6.73 inch, LTPO AMOLED, 120Hz, Dolby Vision<br/>" +
                                 "<strong>Hệ điều hành:</strong> Android 14 (HyperOS)<br/>" +
                                 "<strong>Chip xử lý (CPU):</strong> Snapdragon 8 Gen 3<br/>" +
                                 "<strong>RAM:</strong> 12 GB | <strong>ROM:</strong> 256 GB<br/>" +
                                 "<strong>Camera:</strong> Hệ thống ống kính Leica đỉnh cao 50 MP<br/>" +
                                 "<strong>Pin:</strong> 4880 mAh, Sạc siêu tốc 120W (0-100% trong 18 phút)."
                    },
                    new TbPorduct {
                        ProductId = 4, Name = "Google Pixel 8", CateId = 1, Price = 18000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?q=80&w=500",
                        Description = "Điện thoại Google Pixel 8 Android gốc siêu mượt, camera nhiếp ảnh thuật toán.",
                        Detail = "<strong>Màn hình:</strong> 6.2 inch, OLED, HDR10+, 120Hz<br/>" +
                                 "<strong>Hệ điều hành:</strong> Android 14 (Gốc siêu mượt)<br/>" +
                                 "<strong>Chip xử lý (CPU):</strong> Google Tensor G3 (4 nm)<br/>" +
                                 "<strong>RAM:</strong> 8 GB | <strong>ROM:</strong> 128 GB<br/>" +
                                 "<strong>Camera:</strong> Chính 50 MP, Góc siêu rộng 12 MP (Hỗ trợ AI chụp ảnh đỉnh cao)<br/>" +
                                 "<strong>Pin:</strong> 4575 mAh, Sạc nhanh 27W."
                    },
                    new TbPorduct {
                        ProductId = 5, Name = "Oppo Find X7", CateId = 1, Price = 17000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1592890288564-76628a30a657?q=80&w=500",
                        Description = "Điện thoại Oppo Find X7 cao cấp, sạc siêu nhanh 100W.",
                        Detail = "<strong>Màn hình:</strong> 6.78 inch, LTPO AMOLED, 1 tỷ màu<br/>" +
                                 "<strong>Hệ điều hành:</strong> Android 14 (ColorOS 14)<br/>" +
                                 "<strong>Chip xử lý (CPU):</strong> MediaTek Dimensity 9300<br/>" +
                                 "<strong>RAM:</strong> 12 GB | <strong>ROM:</strong> 256 GB<br/>" +
                                 "<strong>Camera:</strong> Tinh chỉnh bởi Hasselblad, Chính 50 MP<br/>" +
                                 "<strong>Pin:</strong> 5000 mAh, Sạc siêu nhanh SuperVOOC 100W."
                    },
                    new TbPorduct {
                        ProductId = 6, Name = "Sony Xperia 1 V", CateId = 1, Price = 24000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1523206489230-c012c64b2b48?q=80&w=500",
                        Description = "Điện thoại Sony Xperia 1 V màn hình 4K HDR tỷ lệ điện ảnh chuyên giải trí.",
                        Detail = "<strong>Màn hình:</strong> 6.5 inch, 4K HDR OLED, Tỷ lệ 21:9 chuẩn điện ảnh<br/>" +
                                 "<strong>Hệ điều hành:</strong> Android 13<br/>" +
                                 "<strong>Chip xử lý (CPU):</strong> Snapdragon 8 Gen 2<br/>" +
                                 "<strong>RAM:</strong> 12 GB | <strong>ROM:</strong> 256 GB<br/>" +
                                 "<strong>Camera:</strong> Cảm biến Exmor T thế hệ mới, Chụp đêm xuất sắc<br/>" +
                                 "<strong>Pin:</strong> 5000 mAh, Giữ tuổi thọ pin lên tới 3 năm."
                    },
                    new TbPorduct {
                        ProductId = 7, Name = "Asus ROG Phone 8", CateId = 1, Price = 25000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1551645120-d70bfe84c826?q=80&w=500",
                        Description = "Điện thoại Asus ROG Phone 8 cấu hình quái vật chuyên chơi game eSport.",
                        Detail = "<strong>Màn hình:</strong> 6.78 inch, AMOLED, 165Hz (chuyên Game)<br/>" +
                                 "<strong>Hệ điều hành:</strong> Android 14 (ROG UI)<br/>" +
                                 "<strong>Chip xử lý (CPU):</strong> Snapdragon 8 Gen 3<br/>" +
                                 "<strong>RAM:</strong> 16 GB | <strong>ROM:</strong> 256 GB<br/>" +
                                 "<strong>Tính năng:</strong> Tản nhiệt GameCool 8, Nút trigger cảm ứng siêu âm<br/>" +
                                 "<strong>Pin:</strong> 5500 mAh, Sạc nhanh 65W."
                    },
                    new TbPorduct {
                        ProductId = 8, Name = "Nothing Phone 2", CateId = 1, Price = 14000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://m.media-amazon.com/images/I/71W-u2s59VL._AC_SL1500_.jpg",
                        Description = "Điện thoại Nothing Phone 2 thiết kế đèn LED mặt lưng trong suốt độc lạ.",
                        Detail = "<strong>Màn hình:</strong> 6.7 inch, LTPO OLED, 120Hz<br/>" +
                                 "<strong>Hệ điều hành:</strong> Nothing OS 2.5 (Android 14)<br/>" +
                                 "<strong>Chip xử lý (CPU):</strong> Snapdragon 8+ Gen 1<br/>" +
                                 "<strong>RAM:</strong> 12 GB | <strong>ROM:</strong> 256 GB<br/>" +
                                 "<strong>Đặc biệt:</strong> Mặt lưng trong suốt với dải đèn LED Glyph Interface độc đáo<br/>" +
                                 "<strong>Pin:</strong> 4700 mAh, Sạc nhanh 45W."
                    },

                    // --- LAPTOP (CateId = 2) ---
                    new TbPorduct {
                        ProductId = 9, Name = "MacBook Air M3", CateId = 2, Price = 30000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://m.media-amazon.com/images/I/71jG+e7roXL._AC_SL1500_.jpg",
                        Description = "Máy tính xách tay Apple MacBook Air M3 mỏng nhẹ pin trâu dành cho văn phòng.",
                        Detail = "<strong>Màn hình:</strong> 13.6 inch, Liquid Retina display (2560 x 1664)<br/>" +
                                 "<strong>Vi xử lý (CPU):</strong> Apple M3 (8 nhân CPU, 8 nhân GPU)<br/>" +
                                 "<strong>RAM:</strong> 8 GB Unified Memory<br/>" +
                                 "<strong>Ổ cứng:</strong> 256 GB SSD siêu tốc<br/>" +
                                 "<strong>Trọng lượng:</strong> 1.24 kg - Siêu mỏng nhẹ<br/>" +
                                 "<strong>Thời lượng pin:</strong> Lên đến 18 giờ lướt web."
                    },
                    new TbPorduct {
                        ProductId = 10, Name = "Dell XPS 13", CateId = 2, Price = 35000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1593642632823-8f785ba67e45?q=80&w=500",
                        Description = "Laptop Dell XPS 13 tràn viền cao cấp, thiết kế doanh nhân nhôm nguyên khối.",
                        Detail = "<strong>Màn hình:</strong> 13.4 inch, FHD+ (1920 x 1200) Tràn viền InfinityEdge<br/>" +
                                 "<strong>Vi xử lý (CPU):</strong> Intel Core i7-1250U thế hệ 12<br/>" +
                                 "<strong>RAM:</strong> 16 GB LPDDR5<br/>" +
                                 "<strong>Ổ cứng:</strong> 512 GB PCIe NVMe SSD<br/>" +
                                 "<strong>Thiết kế:</strong> Nhôm nguyên khối gia công CNC cao cấp<br/>" +
                                 "<strong>Hệ điều hành:</strong> Windows 11 Home bản quyền."
                    },
                    new TbPorduct {
                        ProductId = 11, Name = "HP Spectre x360", CateId = 2, Price = 32000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://m.media-amazon.com/images/I/71j228M2YdL._AC_SL1500_.jpg",
                        Description = "Laptop HP Spectre x360 xoay gập cảm ứng 2 trong 1 cực kỳ linh hoạt.",
                        Detail = "<strong>Màn hình:</strong> 13.5 inch, 3K2K OLED, Cảm ứng đa điểm<br/>" +
                                 "<strong>Vi xử lý (CPU):</strong> Intel Core i7-1355U<br/>" +
                                 "<strong>RAM:</strong> 16 GB LPDDR4x<br/>" +
                                 "<strong>Ổ cứng:</strong> 512 GB SSD Gen 4<br/>" +
                                 "<strong>Tính năng:</strong> Bản lề xoay gập 360 độ, Tặng kèm bút cảm ứng Stylus<br/>" +
                                 "<strong>Âm thanh:</strong> Loa Bang & Olufsen cao cấp."
                    },
                    new TbPorduct {
                        ProductId = 12, Name = "Asus Zenbook S13", CateId = 2, Price = 28000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?q=80&w=500",
                        Description = "Laptop Asus Zenbook S13 màn hình OLED chuẩn màu cho dân thiết kế đồ họa 2D.",
                        Detail = "<strong>Màn hình:</strong> 13.3 inch, 2.8K (2880 x 1800) OLED 16:10, Đạt chuẩn Pantone<br/>" +
                                 "<strong>Vi xử lý (CPU):</strong> Intel Core i7-1355U<br/>" +
                                 "<strong>RAM:</strong> 16 GB LPDDR5<br/>" +
                                 "<strong>Ổ cứng:</strong> 1 TB SSD M.2 NVMe PCIe 4.0<br/>" +
                                 "<strong>Trọng lượng:</strong> Siêu nhẹ chỉ tròn 1.0 kg, mỏng 1 cm<br/>" +
                                 "<strong>Độ bền:</strong> Đạt tiêu chuẩn quân đội Mỹ MIL-STD 810H."
                    },
                    new TbPorduct {
                        ProductId = 13, Name = "Lenovo Legion 5", CateId = 2, Price = 27000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1588872657578-7efd1f1555ed?q=80&w=500",
                        Description = "Laptop Gaming Lenovo Legion 5 tản nhiệt tốt, chiến game AAA mượt mà.",
                        Detail = "<strong>Màn hình:</strong> 15.6 inch, WQHD (2560x1440), Tần số quét 165Hz chuẩn Gaming<br/>" +
                                 "<strong>Vi xử lý (CPU):</strong> AMD Ryzen 7 7735HS<br/>" +
                                 "<strong>Card đồ họa (VGA):</strong> NVIDIA GeForce RTX 4060 8GB<br/>" +
                                 "<strong>RAM:</strong> 16 GB DDR5 (Có thể nâng cấp)<br/>" +
                                 "<strong>Ổ cứng:</strong> 512 GB SSD PCIe 4.0<br/>" +
                                 "<strong>Phân khúc:</strong> Laptop Gaming quốc dân, hiệu năng tản nhiệt hàng đầu."
                    },
                    new TbPorduct {
                        ProductId = 14, Name = "Surface Laptop 5", CateId = 2, Price = 29000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1585241936939-be4099591252?q=80&w=500",
                        Description = "Máy tính Microsoft Surface Laptop 5 màn hình tỷ lệ 3:2 tối ưu đọc tài liệu.",
                        Detail = "<strong>Màn hình:</strong> 13.5 inch PixelSense Display (2256 x 1504), Cảm ứng<br/>" +
                                 "<strong>Vi xử lý (CPU):</strong> Intel Core i5-1235U thế hệ 12<br/>" +
                                 "<strong>RAM:</strong> 8 GB LPDDR5x<br/>" +
                                 "<strong>Ổ cứng:</strong> 256 GB SSD<br/>" +
                                 "<strong>Thiết kế:</strong> Khung viền nhôm tinh xảo, Phủ vải Alcantara phần kê tay<br/>" +
                                 "<strong>Bảo mật:</strong> Mở khóa khuôn mặt Windows Hello."
                    },
                    new TbPorduct {
                        ProductId = 15, Name = "MSI Stealth 16", CateId = 2, Price = 40000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1541807084-5c52b6b3adef?q=80&w=500",
                        Description = "Laptop Gaming MSI Stealth 16 siêu mỏng nhẹ với card đồ họa RTX 4070 mạnh mẽ.",
                        Detail = "<strong>Màn hình:</strong> 16 inch UHD+ (3840x2400), MiniLED 120Hz<br/>" +
                                 "<strong>Vi xử lý (CPU):</strong> Intel Core i9-13900H đỉnh cao hiệu năng<br/>" +
                                 "<strong>Card đồ họa (VGA):</strong> NVIDIA GeForce RTX 4070 8GB<br/>" +
                                 "<strong>RAM:</strong> 32 GB DDR5<br/>" +
                                 "<strong>Ổ cứng:</strong> 1 TB SSD Gen 4<br/>" +
                                 "<strong>Đặc biệt:</strong> Thân máy hợp kim Magie, Vừa siêu mỏng nhẹ vừa là cỗ máy đồ họa."
                    },
                    new TbPorduct {
                        ProductId = 16, Name = "Razer Blade 14", CateId = 2, Price = 45000000, Status = 1, CreatedDate = DateTime.Now, Image = "https://images.unsplash.com/photo-1525547719571-a2d4ac8945e2?q=80&w=500",
                        Description = "Laptop Gaming cao cấp Razer Blade 14 thiết kế tinh xảo như MacBook.",
                        Detail = "<strong>Màn hình:</strong> 14 inch QHD+ (2560 x 1600), Tần số quét siêu nhanh 240Hz<br/>" +
                                 "<strong>Vi xử lý (CPU):</strong> AMD Ryzen 9 7940HS<br/>" +
                                 "<strong>Card đồ họa (VGA):</strong> NVIDIA GeForce RTX 4070 8GB<br/>" +
                                 "<strong>RAM:</strong> 16 GB DDR5 5600MHz<br/>" +
                                 "<strong>Ổ cứng:</strong> 1 TB M.2 NVMe PCIe 4.0<br/>" +
                                 "<strong>Đặc điểm:</strong> Laptop Gaming cao cấp, Bàn phím LED RGB Chroma từng phím."
                    }
                };

                context.TbPorducts.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}