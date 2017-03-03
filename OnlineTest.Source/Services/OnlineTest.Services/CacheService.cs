namespace OnlineTest.Services
{
    using System;
    using System.Web;
    using System.Web.Caching;
    using Contracts;

    public class CacheService : ICacheService
    {
        private static readonly object LockObject = new object();
        public T Get<T>(string itemName, T data, int durationInDays)
        {
            return (T)HttpRuntime.Cache[itemName];
        }

        public void Remove(string itemName)
        {
            HttpRuntime.Cache.Remove(itemName);
        }

        public void Set(string itemName, object data, int durationInDays)
        {
            if (HttpRuntime.Cache[itemName] == null)
            {
                lock (LockObject)
                {
                    if (HttpRuntime.Cache[itemName] == null)
                    {
                        HttpRuntime.Cache.Insert(
                            itemName,
                            data,
                            null,
                            DateTime.UtcNow.AddSeconds(durationInDays),
                            Cache.NoSlidingExpiration);
                    }
                    else
                    {
                        HttpRuntime.Cache[itemName] = data;
                    }
                }
            }
        }
    }
}
