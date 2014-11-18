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



        Task<int> ICache.AddItemAsync(string key, object value, CacheItemPolicy policy)
        {
            AddItem(key, value, policy);
            return Task.FromResult(0);
        }

        Task<int> ICache.AddItemAsync(string key, object value, DateTimeOffset dateTimeOffset)
        {
            AddItem(key, value, dateTimeOffset);
            return Task.FromResult(0);
        }

        Task<int> ICache.AddItemAsync(string key, object value)
        {
            AddItem(key, value);
            return Task.FromResult(0);
        }

        Task<object> ICache.GetItemAsync(string key)
        {
            return Task.FromResult(GetItem(key));
        }

        Task<object> ICache.GetItemAsync(string key, bool remove)
        {
            return Task.FromResult(GetItem(key,remove));
        }

        Task<T> ICache.GetItemAsync<T>(string key)
        {
            return Task.FromResult<T>(GetItem<T>(key));
        }

        Task<T> ICache.GetItemAsync<T>(string key, bool remove)
        {
            return Task.FromResult<T>(GetItem<T>(key,remove));
        }

        Task<int> ICache.RemoveItemAsync(string key)
        {
            RemoveItem(key);
            return Task.FromResult(0);
        }
    }
}
