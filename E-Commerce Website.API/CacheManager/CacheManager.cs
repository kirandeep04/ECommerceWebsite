namespace E_Commerce_Website.API.CacheManager
{
    public class CacheManager<T> where T : class
    {
        private readonly IMemoryCache _cache;

        public CacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }
        public List<T> Get(string key)
        {
            var ListTEntity = default(List<T>);
            if (_cache.TryGetValue(key, out List<T> CachedData))
            {
                ListTEntity = CachedData;
            }
            return ListTEntity;
        }
        public List<T> Set(string key, List<T> entities)
        {
            return _cache.Set(key, entities, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(1)
            });
        }

       
    }
}
