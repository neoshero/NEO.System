using System.Runtime.Caching;

namespace NEO.Common.Cache
{
    public class MemoryHelper
    {
        private static readonly MemoryCache Cache = MemoryCache.Default;

        public static void Add<TValue>(string key,TValue value)
        {
            if (Cache.Contains(key))
            {
                Cache[key] = value;
            }
            else
            {
                Cache.Add(key, value,null);
            }
        }

        public static bool Contains(string key)
        {
            return Cache.Contains(key);
        }

        public static TValue Get<TValue>(string key)
        {
            return (TValue) Cache[key];
        }

        public static void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}
