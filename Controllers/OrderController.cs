using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Bắt buộc phải có thư viện này để dùng Include()
using Microsoft.AspNetCore.Http;     // Bắt buộc để dùng Session kiểm tra đăng nhập
using System.Linq;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class OrderController : Controller
    {
        // Khai báo kết nối Database
        private readonly WebBanHangContext _context;

        public OrderController(WebBanHangContext context)
        {
            _context = context;
        }

        // ===== ACTION 1: HIỂN THỊ LỊCH SỬ ĐƠN HÀNG (MỚI THÊM) =====
        [HttpGet]
        public IActionResult History()
        {
            // 1. Kiểm tra xem khách hàng đã đăng nhập chưa
            var customerId = HttpContext.Session.GetInt32("CustomerID");
            if (customerId == null)
            {
                // Chưa đăng nhập thì đẩy về trang Login
                return RedirectToAction("Index", "Login");
            }

            // 2. Truy vấn danh sách đơn hàng của khách đó
            var orderHistory = _context.TbOrders
                .Where(o => o.CustomerId == customerId)
                // Tiêu chí: Sắp xếp theo thời gian mới nhất (đơn mới nằm trên)
                .OrderByDescending(o => o.Orderdate)
                .ToList();

            // 3. Trả về giao diện kèm danh sách đơn hàng
            return View(orderHistory);
        }
        // Action xem chi tiết đơn hàng (Dành riêng cho Lịch sử)
        [HttpGet]
        
        public IActionResult DetailsHistory(int id)
        {
            var customerId = HttpContext.Session.GetInt32("CustomerID");
            if (customerId == null) return RedirectToAction("Index", "Login");

            // Include đầy đủ thông tin để không bị N/A
            var order = _context.TbOrders
                .Include(o => o.Customer) // Để lấy Name, Phone, Address
                .Include(o => o.TbOrderDetails)
                    .ThenInclude(od => od.Product) // Để lấy Name và Image sản phẩm
                .FirstOrDefault(o => o.OrderId == id && o.CustomerId == customerId);

            if (order == null) return RedirectToAction("History");

            return View(order);
        }

        // ===== ACTION 2: HIỂN THỊ CHI TIẾT 1 ĐƠN HÀNG (CŨ CỦA BẠN) =====
        [HttpGet]
        public IActionResult Details(int id)
        {
            // 1. Kiểm tra xem khách hàng đã đăng nhập chưa
            var customerId = HttpContext.Session.GetInt32("CustomerID");
            if (customerId == null)
            {
                // Nếu chưa đăng nhập, đá văng về trang đăng nhập
                return RedirectToAction("Index", "Login");
            }

            // 2. Kéo dữ liệu đơn hàng thật từ Database
            // Sử dụng Include để JOIN các bảng lại với nhau
            var order = _context.TbOrders
                .Include(o => o.Customer)         // Lấy thông tin người đặt
                .Include(o => o.Address)          // Lấy thông tin địa chỉ giao hàng (nếu có)
                .Include(o => o.TbOrderDetails)   // Lấy danh sách chi tiết đơn hàng (các dòng sản phẩm)
                    .ThenInclude(od => od.Product)// Từ chi tiết đơn, lấy ra thông tin Sản phẩm tương ứng (Tên, Ảnh)
                .FirstOrDefault(o => o.OrderId == id && o.CustomerId == customerId);

            // 3. Nếu đơn hàng không tồn tại hoặc ID đơn hàng không phải của ông khách đang đăng nhập
            if (order == null)
            {
                // Bạn có thể trả về lỗi 404 hoặc đưa về trang Profile
                return RedirectToAction("Profile", "Login");
            }

            // 4. Đẩy dữ liệu thật ra ngoài View
            return View(order);
        }
    }
}