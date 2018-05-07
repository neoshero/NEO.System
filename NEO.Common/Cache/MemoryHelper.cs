using System.Runtime.Caching;

namespace NEO.Common.Cache
{
    public class MemoryHelper
    {
        private static readonly MemoryCache cache = MemoryCache.Default;

        public static void Add<TValue>(string key,TValue value)
        {
            if (cache.Contains(key))
            {
                cache[key] = value;
            }
            else
            {
                cache.Add(key, value,null);
            }
        }

        public static bool Contains(string key)
        {
            return cache.Contains(key);
        }

        public static TValue Get<TValue>(string key)
        {
            return (TValue) cache[key];
        }

        public static void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}
