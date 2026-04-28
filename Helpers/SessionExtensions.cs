using System.Text.Json;

namespace WebBanHang.Helpers
{
    public static class SessionExtensions
    {
        // Hàm lưu Object vào Session (Set)
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Hàm lấy Object từ Session ra (Get)
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}