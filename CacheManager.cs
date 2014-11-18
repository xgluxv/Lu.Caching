using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
namespace Lu.Caching
{
    public class CacheManager:ICache 
    {
        private ICache _cache;


        public CacheManager()
        {

        }

        public CacheManager(ICache cache)
        {
            _cache = cache;
        }

        public ICache CacheInstance
        {
            get
            {
                return _cache == null ? _cache = new CachingProvider() : _cache;
            }
        }


        public void AddItem(string key, object value, System.Runtime.Caching.CacheItemPolicy policy)
        {
            CacheInstance.AddItem(key, value, policy);
        }

        public void AddItem(string key, object value, DateTimeOffset dateTimeOffset)
        {
            CacheInstance.AddItem(key, value, dateTimeOffset);
        }

        public void AddItem(string key, object value)
        {
            CacheInstance.AddItem(key, value);
        }

        public object GetItem(string key)
        {
            return CacheInstance.GetItem(key);
        }

        public object GetItem(string key, bool remove)
        {
            return CacheInstance.GetItem(key, remove);
        }

        public T GetItem<T>(string key)
        {
            return CacheInstance.GetItem<T>(key);
        }

        public T GetItem<T>(string key, bool remove)
        {
            return CacheInstance.GetItem<T>(key, remove);
        }

        public void RemoveItem(string key)
        {
            CacheInstance.RemoveItem(key);
        }


        public Task<bool> AddItemAsync(string key, object value, CacheItemPolicy policy)
        {
            return CacheInstance.AddItemAsync(key, value, policy);
        }

        public Task<bool> AddItemAsync(string key, object value, DateTimeOffset dateTimeOffset)
        {
            return CacheInstance.AddItemAsync(key, value, dateTimeOffset);
        }

        public Task<bool> AddItemAsync(string key, object value)
        {
            return CacheInstance.AddItemAsync(key, value);
        }

        public Task<object> GetItemAsync(string key)
        {
            return CacheInstance.GetItemAsync(key);
        }

        public Task<object> GetItemAsync(string key, bool remove)
        {
            return CacheInstance.GetItemAsync(key,remove);
        }

        public Task<T> GetItemAsync<T>(string key)
        {
            return CacheInstance.GetItemAsync<T>(key);
        }

        public Task<T> GetItemAsync<T>(string key, bool remove)
        {
            return CacheInstance.GetItemAsync<T>(key,remove);
        }

        public Task<bool> RemoveItemAsync(string key)
        {
            return CacheInstance.RemoveItemAsync(key);
        }
    }
}
