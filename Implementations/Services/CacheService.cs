using Microsoft.Extensions.Caching.Memory;

namespace Intefaces.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache? _memoryCache;
        private readonly Dictionary<string, TimeSpan> _expirationConfiguration;
        public CacheService(IMemoryCache? memoryCache, Dictionary<string, TimeSpan> expirationConfiguration)
        {
            _memoryCache = memoryCache;
            _expirationConfiguration = expirationConfiguration;
        }
        public void Add<TItem>(TItem item, ICacheKey<TItem> key)
        {
            var cachedObjectName = item!.GetType().Name;
            var timespan = _expirationConfiguration[cachedObjectName];

            this._memoryCache.Set(key.CacheKey, item, timespan);
        }

        public TItem? Get<TItem>(ICacheKey<TItem> key) where TItem : class
        {
            if (this._memoryCache.TryGetValue(key.CacheKey, out TItem value))
            {
                return value;
            }

            return null;
        }
    }
}
