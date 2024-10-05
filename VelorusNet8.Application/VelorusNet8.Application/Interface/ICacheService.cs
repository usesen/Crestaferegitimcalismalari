namespace VelorusNet8.Application.Interface;

public interface ICacheService
{
    Task<T> GetCacheValueAsync<T>(string key);
    Task SetCacheValueAsync<T>(string key, T value, TimeSpan expiration);
}
