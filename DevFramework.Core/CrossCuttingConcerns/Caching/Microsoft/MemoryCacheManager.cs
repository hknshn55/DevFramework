using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //protected ObjectCache Cache
        //{
        //    get
        //    {
        //        return MemoryCache.Default;
        //    }
        //}

        protected ObjectCache Cache => MemoryCache.Default;

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Add(string key, object data, int cacheTime=60)
        {
            if (data==null)
            {
                return;
            }
            var policy = new CacheItemPolicy
            {  //Cache süresi belirtir.
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };
            //Cache nesnesi ekliyoruz.
            Cache.Add(new CacheItem(key, data), policy);

        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }
        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(
                pattern,
                RegexOptions.Singleline|
                RegexOptions.Compiled|
                RegexOptions.IgnoreCase
                );
            var keysToRemove = Cache.Where(x => regex.IsMatch(x.Key)).Select(x => x.Key).ToList();
            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
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
