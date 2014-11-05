using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Lu.Caching
{
    public interface ICache
    {
        void AddItem(string key, object value, CacheItemPolicy policy);
        void AddItem(string key, object value, DateTimeOffset dateTimeOffset);
        void AddItem(string key, object value);
        object GetItem(string key);
        object GetItem(string key,bool remove);
        T GetItem<T>(string key);
        T GetItem<T>(string key, bool remove);

        void RemoveItem(string key);
    }
}
