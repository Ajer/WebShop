using System.Text.Json;

namespace WebShop.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
            session.CommitAsync().Wait();
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            session.LoadAsync().Wait();     //---------

            var sessData = session.GetString(key);
            return (sessData == null) ? default(T) : JsonSerializer.Deserialize<T>(sessData);
        }
    }
}
