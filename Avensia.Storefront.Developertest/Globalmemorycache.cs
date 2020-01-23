using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Avensia.Storefront.Developertest
{
   static class Globalmemorycache
    {

        static MemoryCache cache = new MemoryCache("Memorycache");
        static CacheItemPolicy cachepolicy = new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddMinutes(3) };

        public static void AddItem(string Key, object MyValue)
        {
            cache.Add(Key, MyValue, cachepolicy);
            
        }
        public static void Removecache(string Key, object MyValue)
        {
            cache.Remove(Key);

        }

        public  static object GetItem(string Key)
        {
            return cache[Key];

        }
        public static bool isExist(string Key)
        {
            if (cache[Key] == null)
            {
                return false;
            }
            return true;
        }

       

        public static string Pushtocache(string strJson, string name)
        {
            if (Globalmemorycache.isExist(name))
            {
               strJson=  Globalmemorycache.GetItem(name).ToString();
            }
            else
            {
                
                Globalmemorycache.AddItem(name, strJson);
            }
            return strJson;
        }
    }
}
