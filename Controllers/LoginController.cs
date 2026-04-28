using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models;
using WebBanHang.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using BCrypt.Net;
using System.Net.Mail;
using System.Net;

namespace WebBanHang.Controllers
{
    public class LoginController : Controller
    {
        private readonly WebBanHangContext _context;

        public LoginController(WebBanHangContext context)
        {
            _context = context;
        }

        // ===== TRANG ĐĂNG NHẬP =====
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            try
            {
                var customer = _context.TbCustomers.FirstOrDefault(c => c.Email == email);

                if (customer != null && customer.Status == 1)
                {
                    // Kiểm tra mật khẩu (Sử dụng BCrypt để so khớp hash)
                    if (BCrypt.Net.BCrypt.Verify(password, customer.Password))
                    {
                        HttpContext.Session.SetInt32("CustomerID", customer.CustomerId);
                        HttpContext.Session.SetString("FullName", customer.Name ?? "");
                        HttpContext.Session.SetString("Username", customer.Email ?? "");
                        HttpContext.Session.SetInt32("Role", customer.RoleId ?? 0);

                        return RedirectToAction("Index", "Home");
                    }
                }

                ViewBag.Error = "Email hoặc mật khẩu không chính xác.";
                return View();
            }
            catch (Exception ex)
            {
                // ⚠️ DEBUG TẠM THỜI: Hiển thị lỗi ra màn hình để tìm nguyên nhân
                // Sau khi tìm được lỗi, hãy XÓA block catch này đi
                ViewBag.Error = "🔴 LỖI: " + ex.Message
                              + (ex.InnerException != null ? " | Chi tiết: " + ex.InnerException.Message : "");
                return View();
            }
        }

        // ===== TRANG ĐĂNG KÝ =====
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var existingCustomer = _context.TbCustomers.FirstOrDefault(c => c.Email == model.Email);
            if (existingCustomer != null)
            {
                ModelState.AddModelError("", "Email này đã được sử dụng.");
                return View(model);
            }

            // TẠO ĐỐI TƯỢNG KHÁCH HÀNG MỚI
            var newCustomer = new TbCustomer
            {
                Name = model.FullName,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Phone = "",
                Address = "",
                Status = 1,
                CreatedDate = DateTime.Now
            };

            _context.TbCustomers.Add(newCustomer);
            _context.SaveChanges();

            TempData["Success"] = "Đăng ký thành công! Hãy đăng nhập.";
            return RedirectToAction("Index");
        }

        // ===== QUÊN MẬT KHẨU (Gửi OTP) =====
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var customer = _context.TbCustomers.FirstOrDefault(c => c.Email == model.Email);
            if (customer == null)
            {
                ViewBag.Error = "Email không tồn tại trong hệ thống.";
                return View(model);
            }

            // Tạo mã OTP 6 số ngẫu nhiên
            string otp = Random.Shared.Next(100000, 999999).ToString();

            // Lưu OTP vào bảng Reset (Hết hạn sau 5 phút)
            var resetRecord = new TbPasswordReset
            {
                CustomerId = customer.CustomerId,
                Token = BCrypt.Net.BCrypt.HashPassword(otp),
                ExprireData = DateTime.Now.AddMinutes(5).ToString("O")
            };
            _context.TbPasswordResets.Add(resetRecord);
            _context.SaveChanges();

            // Gửi mã OTP đến Email của khách hàng
            SendEmailOTP(model.Email, otp);

            return RedirectToAction("ResetPassword", new { email = model.Email });
        }

        // ===== ĐẶT LẠI MẬT KHẨU (Xác nhận OTP) =====
        public IActionResult ResetPassword(string email)
        {
            return View(new ResetPasswordViewModel { Email = email });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var customer = _context.TbCustomers.FirstOrDefault(c => c.Email == model.Email);
            var resetRequest = _context.TbPasswordResets
                .Where(r => r.CustomerId == customer.CustomerId)
                .OrderByDescending(r => r.Id)
                .FirstOrDefault();

            if (resetRequest == null || DateTime.Now > DateTime.Parse(resetRequest.ExprireData))
            {
                ViewBag.Error = "Mã OTP đã hết hạn hoặc không tồn tại.";
                return View(model);
            }

            if (!BCrypt.Net.BCrypt.Verify(model.OTP, resetRequest.Token))
            {
                ViewBag.Error = "Mã OTP không chính xác.";
                return View(model);
            }

            // Cập nhật mật khẩu mới
            customer.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            _context.TbPasswordResets.Remove(resetRequest);
            _context.SaveChanges();

            TempData["Success"] = "Đổi mật khẩu thành công!";
            return RedirectToAction("Index");
        }

        // ===== ĐĂNG XUẤT =====
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        // Action hiển thị trang cá nhân
        [HttpGet]
        public IActionResult Profile()
        {
            // 1. Lấy ID khách hàng từ Session
            var customerId = HttpContext.Session.GetInt32("CustomerID");
            if (customerId == null)
            {
                return RedirectToAction("Index", "Login"); // Chưa đăng nhập thì bắt đăng nhập
            }

            // 2. Tìm thông tin khách hàng trong DB
            var customer = _context.TbCustomers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(customer); // Trả về trang Profile kèm dữ liệu khách hàng
        }
        // 🛡️ HÀM GỬI EMAIL TỰ ĐỘNG
        private void SendEmailOTP(string toEmail, string otp)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("nguyenchanhhung2.qng06@gmail.com", "wrrexqdryvrjcdym"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("nguyenchanhhung2.qng06@gmail.com", "Web Bán Hàng"),
                    Subject = "Mã xác thực OTP của bạn",
                    Body = $"<div style='font-family:Arial; padding:20px; border:1px solid #ddd;'>" +
                           $"<h2 style='color:#e63946;'>Xác thực tài khoản</h2>" +
                           $"<p>Chào bạn, mã OTP của bạn để khôi phục mật khẩu là:</p>" +
                           $"<h1 style='background:#f8f9fa; padding:10px; text-align:center; letter-spacing:5px;'>{otp}</h1>" +
                           $"<p>Mã này sẽ <b>hết hạn trong 5 phút</b>. Vui lòng không chia sẻ mã này cho bất kỳ ai.</p>" +
                           $"</div>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi gửi mail: " + ex.Message);
            }
        }
    }
}