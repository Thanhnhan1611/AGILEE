using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebBanHang.Models;
using Microsoft.AspNetCore.Http;
using WebBanHang.Models;  // Để hết lỗi đỏ ở chữ CartItem
using WebBanHang.Helpers; // Để hết lỗi đỏ ở hàm .Get và .Set

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebBanHangContext _context;

        public HomeController(ILogger<HomeController> logger, WebBanHangContext context)
        {
            _logger = logger;
            _context = context;
        }

        // ===== TRANG CHỦ =====
        public IActionResult Index()
        {
            // Gọi đúng tên bảng TbPorducts (nhớ chữ o bị dư)
            var listSanPham = _context.TbPorducts.ToList();

            // Gửi danh sách sang View
            return View(listSanPham);
        }

        // ===== CHI TIẾT ĐƠN HÀNG =====
        public IActionResult OrderDetails(int id)
        {
            var order = _context.TbOrders
                .Include(o => o.TbOrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // ===== TÌM KIẾM =====
        public IActionResult SearchProduct(string tensp)
        {
            if (string.IsNullOrEmpty(tensp))
            {
                return RedirectToAction("Index");
            }

            string keyword = tensp.ToLower();

            var results = _context.TbPorducts
                                 .Where(p => p.Name != null && p.Name.ToLower().Contains(keyword))
                                 .ToList();

            ViewBag.Brands = _context.TbBrands.ToList();
            ViewBag.Categories = _context.TbProductCategories.ToList();
            ViewBag.TuKhoa = tensp;

            return View("Index", results);
        }
        // ===== XEM THÔNG TIN TÀI KHOẢN =====
        public IActionResult Profile()
        {
            // Lấy ID khách hàng từ Session
            var customerId = HttpContext.Session.GetInt32("CustomerID");

            if (customerId == null)
            {
                return RedirectToAction("Index"); // Chưa đăng nhập thì đá về trang Login
            }

            var customer = _context.TbCustomers.Find(customerId);
            return View(customer);
        }
        public IActionResult ProductDetail(int id)
        {
            // Tìm sản phẩm theo ID trong Database
            // Nhớ dùng đúng tên TbPorducts (sai chính tả giống file Context của bạn)
            var product = _context.TbPorducts
                                  .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(); // Nếu không thấy sản phẩm thì báo lỗi
            }

            return View(product);
        }
        

        // ===== CHECKOUT =====
        public IActionResult Checkout()
        {
            return View();
        }

        // ===== CHI TIẾT GIỎ HÀNG (SỬA LẠI) =====
        public IActionResult Cart()
        {
            // Lấy dữ liệu thật từ Session, nếu trống thì trả về danh sách rỗng
            var model = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(model);
        }

        // ===== THÊM VÀO GIỎ HÀNG (THÊM MỚI) =====
        public IActionResult AddToCart(int id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart") ?? new List<CartItem>();
            var item = cart.SingleOrDefault(p => p.MaHh == id);

            if (item == null)
            {
                var product = _context.TbPorducts.Find(id); // Nhớ đúng tên bảng TbPorducts của bạn
                if (product != null)
                {
                    cart.Add(new CartItem
                    {
                        MaHh = product.ProductId,
                        TenHh = product.Name,
                        DonGia = (double)(product.Price ?? 0m),
                        Hinh = product.Image,
                        SoLuong = 1
                    });
                }
            }
            else
            {
                item.SoLuong++;
            }

            HttpContext.Session.Set("Cart", cart);

            // TRẢ VỀ OK ĐỂ JAVASCRIPT CHẠY TIẾP
            return Ok();
        }
        public IActionResult RemoveCart(int id)
        {
            // 1. Lấy giỏ hàng hiện tại ra
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart");

            if (cart != null)
            {
                // 2. Tìm món hàng có ID khớp và xóa khỏi danh sách
                var item = cart.SingleOrDefault(p => p.MaHh == id);
                if (item != null)
                {
                    cart.Remove(item);
                }

                // 3. Lưu lại giỏ hàng mới vào Session
                HttpContext.Session.Set("Cart", cart);
            }

            // 4. Quay lại trang giỏ hàng để thấy kết quả đã xóa
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            // Kiểm tra Session "Username" đã tồn tại chưa
            if (HttpContext.Session.GetString("Username") == null)
            {
                // Nếu chưa có, chuyển hướng về trang đăng nhập
                return RedirectToAction("Index", "Login");
            }

            // Nếu đã đăng nhập thì mới chạy tiếp code thêm hàng bên dưới
            // ... code thêm hàng của bạn ...
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HttpPost]
        [HttpPost]
        public IActionResult Checkout(string fullName, string phone, string address)
        {
            // 1. Lấy ID người dùng từ Session
            var customerId = HttpContext.Session.GetInt32("CustomerID");
            if (customerId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // 2. CẬP NHẬT SĐT VÀ ĐỊA CHỈ VÀO THÔNG TIN KHÁCH HÀNG
            var customer = _context.TbCustomers.Find(customerId);
            if (customer != null)
            {
                customer.Phone = phone;
                customer.Address = address;
                customer.Name = fullName;
                _context.TbCustomers.Update(customer);
            }

            // 3. Tạo đơn hàng (TbOrder)
            var order = new TbOrder
            {
                CustomerId = customerId,
                Orderdate = DateTime.Now,
                Status = 1
            };
            _context.TbOrders.Add(order);
            _context.SaveChanges(); // Lưu để DB tự tạo OrderId

            // 4. LƯU CHI TIẾT ĐƠN HÀNG (ĐÃ SỬA LỖI TÊN BIẾN)
            var cart = HttpContext.Session.Get<List<CartItem>>("Cart");
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    var detail = new TbOrderDetail
                    {
                        OderId = order.OrderId,       // Mã đơn hàng vừa tạo
                        ProductId = item.MaHh,        // SỬA: Lấy mã hàng từ MaHh
                        Price = (decimal)item.DonGia, // SỬA: Lấy giá từ DonGia và ép kiểu sang decimal
                        Quanlity = item.SoLuong       // SỬA: Lấy số lượng từ SoLuong
                    };
                    _context.TbOrderDetails.Add(detail);
                }
                _context.SaveChanges(); // Lưu tất cả mặt hàng vào DB
            }

            // 5. Dọn dẹp và Thông báo
            HttpContext.Session.Remove("Cart");
            TempData["SuccessMessage"] = "Đã thanh toán đơn hàng vui lòng kiểm tra lịch sử đơn hàng";

            return RedirectToAction("Index", "Home");
        }
        public IActionResult CancelOrder(int id)
        {
            // 1. Kiểm tra đăng nhập
            var customerId = HttpContext.Session.GetInt32("CustomerID");
            if (customerId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // 2. Tìm đơn hàng
            var order = _context.TbOrders.FirstOrDefault(o => o.OrderId == id && o.CustomerId == customerId);

            if (order == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy đơn hàng.";
                return RedirectToAction("History", "Order");
            }

            // 3. Logic Hủy đơn
            if (order.Status == 1)
            {
                // A. Cập nhật trạng thái thành 0 (Đã hủy)
                order.Status = 0;
                _context.TbOrders.Update(order);

                // B. Cộng trả lại kho
                var details = _context.TbOrderDetails.Where(d => d.OderId == id).ToList();
                foreach (var item in details)
                {
                    var product = _context.TbPorducts.Find(item.ProductId);
                    if (product != null)
                    {
                        product.Quanlity += item.Quanlity;
                        _context.TbPorducts.Update(product);
                    }
                }

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Hủy đơn hàng thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể hủy đơn hàng ở trạng thái này.";
            }

            Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            return RedirectToAction("History", "Order");
        }
    }

    }
