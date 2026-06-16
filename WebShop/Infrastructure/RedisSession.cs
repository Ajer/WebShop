using StackExchange.Redis;
using System.Text.Json;

// Class for testing of redis-sessions. Not used.
namespace WebShop.Infrastructure
{
    public class RedisSession
    {
        private readonly IDatabase _db;

        public RedisSession(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public void Set<T>(string key, T value, TimeSpan ttl)
        {
            var json = JsonSerializer.Serialize(value);
            _db.StringSet(key, json, ttl);
        }

        public  T? Get<T>(string key)
        {
            var value =  _db.StringGet(key);
            if (value.IsNullOrEmpty) return default;
            return JsonSerializer.Deserialize<T>(value!);
        }

        public void Delete(string key)
        {
            _db.KeyDelete(key);
        }
    }
}
