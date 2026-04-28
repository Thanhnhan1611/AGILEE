using WebBanHang.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. ĐĂNG KÝ CÁC DỊCH VỤ (SERVICES)
// ==========================================

// Đăng ký DbContext (Kết nối SQLite)
builder.Services.AddDbContext<WebBanHangContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cấu hình Session (Bộ nhớ lưu trạng thái Đăng nhập)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Session sống 60 phút
    options.Cookie.HttpOnly = true;                 // Bảo mật Cookie
    options.Cookie.IsEssential = true;              // CỰC KỲ QUAN TRỌNG: Ép trình duyệt không được chặn Cookie này
});

builder.Services.AddControllersWithViews();

// Xây dựng ứng dụng
var app = builder.Build();

// ==========================================
// 2. CẤU HÌNH MIDDLEWARE (PIPELINE)
// ==========================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Cho phép đọc file CSS, JS, Images trong wwwroot

app.UseRouting();

// BẬT SESSION (Bắt buộc phải nằm sau UseRouting và trước UseAuthorization)
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ==========================================
// 3. KHỞI TẠO DỮ LIỆU MẪU (SEED DATA)
// ==========================================
Console.WriteLine("--- DANG KHOI TAO DU LIEU MAU (ADMIN & SAN PHAM) ---");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<WebBanHangContext>();
    WebBanHang.Data.DbInitializer.Initialize(context);
}

// ==========================================
// 4. CHẠY ỨNG DỤNG
// ==========================================
app.Run();