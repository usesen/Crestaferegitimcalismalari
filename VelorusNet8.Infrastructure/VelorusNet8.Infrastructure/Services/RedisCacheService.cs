using StackExchange.Redis;
using System.Text.Json;
using VelorusNet8.Application.Interface;  // ICacheService'in olduğu namespace

namespace VelorusNet8.Infrastructure.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _redisDb;
        private static ConnectionMultiplexer _redis;

        public RedisCacheService(string redisConnectionString)
        {
            _redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _redisDb = _redis.GetDatabase();
        }

        public async Task<T> GetCacheValueAsync<T>(string key)
        {
            var value = await _redisDb.StringGetAsync(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default(T);
        }

        public async Task SetCacheValueAsync<T>(string key, T value, TimeSpan expiration)
        {
            var jsonData = JsonSerializer.Serialize(value);
            await _redisDb.StringSetAsync(key, jsonData, expiration);
        }
    }
}
