using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Models;
using System.Linq;
using System;

namespace WebBanHang.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly WebBanHangContext _context;

        public AdminUserController(WebBanHangContext context)
        {
            _context = context;
        }

        // ==========================================
        // PHẦN 1: QUẢN LÝ TÀI KHOẢN (USER)
        // ==========================================

        public IActionResult Index(string search)
        {
            var query = _context.TbCustomers.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                query = query.Where(u => (u.Name != null && u.Name.ToLower().Contains(search)) ||
                                         (u.Email != null && u.Email.ToLower().Contains(search)));
            }
            ViewBag.SearchTerm = search;
            return View(query.ToList());
        }

        [HttpPost]
        public IActionResult ToggleLock(int id)
        {
            var user = _context.TbCustomers.Find(id);
            if (user != null)
            {
                user.Status = (user.Status == 1) ? 0 : 1;
                _context.SaveChanges();
                TempData["Message"] = user.Status == 1 ? "Đã mở khóa tài khoản!" : "Đã khóa tài khoản!";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HttpPost]
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            // Kiểm tra quyền (Nếu bạn đã thêm hàm IsAdmin từ trước)
            // if (!IsAdmin()) return RedirectToAction("Index", "Login");

            var customer = _context.TbCustomers.Find(id);
            if (customer == null) return NotFound();

            try
            {
                // 1. TÌM VÀ XÓA: BÌNH LUẬN & GIỎ HÀNG (Nếu web của bạn có các bảng này)
                // Mở comment ra nếu bạn có dùng các bảng này nhé:
                /*
                var comments = _context.TbProductComments.Where(c => c.CustomerId == id).ToList();
                _context.TbProductComments.RemoveRange(comments);

                var carts = _context.TbCarts.Where(c => c.CustomerId == id).ToList();
                _context.TbCarts.RemoveRange(carts);
                */

                // 2. TÌM TẤT CẢ ĐƠN HÀNG CỦA KHÁCH
                var orders = _context.TbOrders.Where(o => o.CustomerId == id).ToList();

                // Lấy ra danh sách các mã đơn hàng (OrderId)
                var orderIds = orders.Select(o => o.OrderId).ToList();

                // 3. XÓA "CHÁU" (CHI TIẾT ĐƠN HÀNG) TRƯỚC
                // Tìm tất cả chi tiết đơn hàng thuộc về các đơn hàng ở trên
                var orderDetails = _context.TbOrderDetails.Where(od => orderIds.Contains(od.OderId)).ToList();
                _context.TbOrderDetails.RemoveRange(orderDetails);

                // 4. XÓA "CON" (ĐƠN HÀNG)
                _context.TbOrders.RemoveRange(orders);

                // 5. CUỐI CÙNG: XÓA "CHA" (KHÁCH HÀNG)
                _context.TbCustomers.Remove(customer);

                // 6. LƯU THAY ĐỔI
                _context.SaveChanges();
                TempData["Success"] = "Đã nhổ tận gốc tài khoản và toàn bộ dữ liệu liên quan!";
            }
            catch (Exception ex)
            {
                // Nếu vẫn còn sót bảng nào đó chưa xóa, hệ thống sẽ báo tên lỗi ra thay vì sập web
                TempData["Error"] = "Không thể xóa! Vẫn còn dữ liệu liên kết chưa được dọn dẹp. Lỗi: " + ex.InnerException?.Message;
            }

            return RedirectToAction("Index");
        }

        // ==========================================
        // PHẦN 2: QUẢN LÝ SẢN PHẨM (PRODUCT)
        // ==========================================

        public IActionResult ManageProducts()
        {
            var products = _context.TbPorducts.ToList();
            return View(products);
        }

        public IActionResult CreateProduct() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(TbPorduct product)
        {
            if (ModelState.IsValid)
            {
                int maxId = _context.TbPorducts.Any() ? _context.TbPorducts.Max(p => p.ProductId) : 0;
                product.ProductId = maxId + 1;
                product.CreatedDate = DateTime.Now;
                _context.TbPorducts.Add(product);
                _context.SaveChanges();
                TempData["Message"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("ManageProducts");
            }
            return View(product);
        }

        public IActionResult EditProduct(int id)
        {
            var product = _context.TbPorducts.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(TbPorduct product)
        {
            if (ModelState.IsValid)
            {
                product.UpdatedDate = DateTime.Now;
                _context.Update(product);
                _context.SaveChanges();
                TempData["Message"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("ManageProducts");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.TbPorducts.Find(id);
            if (product != null)
            {
                _context.TbPorducts.Remove(product);
                _context.SaveChanges();
                TempData["Message"] = "Đã xóa sản phẩm thành công!";
            }
            return RedirectToAction("ManageProducts");
        }

        // ==========================================
        // PHẦN 3: QUẢN LÝ ĐƠN HÀNG (ORDER) - MỚI THÊM
        // ==========================================

        // 1. Xem danh sách tất cả đơn hàng
        public IActionResult ManageOrders()
        {
            // Lấy danh sách kèm thông tin khách hàng để Admin dễ theo dõi
            var orders = _context.TbOrders.Include(o => o.Customer).OrderByDescending(o => o.Orderdate).ToList();
            return View(orders);
        }

        // 2. Xác nhận giao hàng (Chuyển từ 1 -> 2)
        [HttpPost]
        public IActionResult ConfirmDelivery(int id)
        {
            var order = _context.TbOrders.Find(id);
            if (order != null && order.Status == 1) // Chỉ xác nhận khi đang "Chờ xử lý"
            {
                order.Status = 2; // Gán 2 là "Đang giao hàng"
                _context.TbOrders.Update(order);
                _context.SaveChanges();
                TempData["Message"] = "Đã chuyển đơn hàng #" + id + " sang trạng thái Đang giao hàng.";
            }
            return RedirectToAction("ManageOrders");
        }

        // 3. Hoàn thành đơn hàng (Chuyển từ 2 -> 3)
        [HttpPost]
        public IActionResult CompleteOrder(int id)
        {
            var order = _context.TbOrders.Find(id);
            if (order != null && order.Status == 2) // Chỉ hoàn thành khi đang "Đang giao"
            {
                order.Status = 3; // Gán 3 là "Đã hoàn thành"
                _context.TbOrders.Update(order);
                _context.SaveChanges();
                TempData["Message"] = "Đơn hàng #" + id + " đã giao thành công!";
            }
            return RedirectToAction("ManageOrders");
        }
    }
}