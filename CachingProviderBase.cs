using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
namespace Lu.Caching
{
    public abstract class CachingProviderBase:ICache
    {
        private const string CacheZoneName = "Lu.Caching";
        private static readonly MemoryCache cache = new MemoryCache(CacheZoneName);


        public virtual void AddItem(string key, object value, CacheItemPolicy policy)
        {
            if (cache.Contains(key))
            {
                cache.Remove(key);
            }
            cache.Add(key, value, policy);
        }

        public virtual void AddItem(string key, object value, DateTimeOffset dateTimeOffset)
        {
            if (cache.Contains(key))
            {
                cache.Remove(key);
            }
            cache.Add(key, value, dateTimeOffset);
        }

        public virtual void AddItem(string key, object value)
        {
            var policy= new CacheItemPolicy();
            policy.Priority=CacheItemPriority.NotRemovable;
            AddItem(key, value, policy);
        }

        public virtual object GetItem(string key)
        {
            return GetItem(key, false);
        }

        public virtual object GetItem(string key, bool remove)
        {
            if(cache.Contains(key))
            {
                var item = cache.Get(key);
                if (remove)
                    RemoveItem(key);
                return item;
            }
            return null;
        }

        public virtual T GetItem<T>(string key)
        {
            return GetItem<T>(key, false);
        }

        public virtual T GetItem<T>(string key, bool remove)
        {
            return (T)GetItem(key, remove);
        }

        public virtual void RemoveItem(string key)
        {
            cache.Remove(key);
        }
    }
}
