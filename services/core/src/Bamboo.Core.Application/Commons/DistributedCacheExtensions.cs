using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Threading.Tasks;

public static class DistributedCacheExtensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    // Lưu object bất kỳ
    public static async Task SetObjectAsync<T>(
        this IDistributedCache cache,
        string key,
        T value,
        DistributedCacheEntryOptions? options = null)
    {
        if (value == null)
        {
            await cache.RemoveAsync(key);
            return;
        }

        var json = JsonSerializer.Serialize(value, _jsonOptions);
        await cache.SetStringAsync(key, json, options ?? new DistributedCacheEntryOptions());
    }

    // Lấy object bất kỳ
    public static async Task<T?> GetObjectAsync<T>(
        this IDistributedCache cache,
        string key)
    {
        var json = await cache.GetStringAsync(key);
        return json == null ? default : JsonSerializer.Deserialize<T>(json, _jsonOptions);
    }
}
