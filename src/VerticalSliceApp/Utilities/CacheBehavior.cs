using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace VerticalSliceApp.Utilities;

public sealed class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<CacheBehavior<TRequest, TResponse>> _logger;

    public CacheBehavior(IMemoryCache cache, ILogger<CacheBehavior<TRequest, TResponse>> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var cacheAttribute = request.GetType().GetCustomAttributes(typeof(CacheAttribute), true).FirstOrDefault() as CacheAttribute;
        if (cacheAttribute == null)
        {
            return await next();
        }

        var cacheKey = GetCacheKey(request);
        if (_cache.TryGetValue(cacheKey, out TResponse response))
        {
            _logger.LogInformation($"Cache hit for {cacheKey}");
            return response;
        }
        else
        {
            _logger.LogInformation($"Cache miss for {cacheKey}");
            response = await next();
            var options = new MemoryCacheEntryOptions();
            if (cacheAttribute.AbsoluteExpirationRelativeToNowInSeconds > 0)
            {
                options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheAttribute.AbsoluteExpirationRelativeToNowInSeconds);
            }

            if (cacheAttribute.SlidingExpirationInSeconds > 0)
            {
                options.SlidingExpiration = TimeSpan.FromSeconds(cacheAttribute.SlidingExpirationInSeconds);
            }

            _cache.Set(cacheKey, response, options);
            return response;
        }
    }

    private string GetCacheKey(TRequest request)
        => JsonSerializer.Serialize(request);
}
