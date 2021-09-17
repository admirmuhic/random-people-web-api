using System;
using System.Threading.Tasks;

namespace RandomPeopleWebAPI.Services
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLivw);
        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
