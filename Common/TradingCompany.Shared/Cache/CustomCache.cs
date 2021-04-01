namespace TradingCompany.Shared
{
	using Microsoft.Extensions.Caching.Distributed;
	using Newtonsoft.Json;

	public class CustomCache : ICustomCache
	{
		private readonly IDistributedCache distributedCache;

		public CustomCache(IDistributedCache distributedCache)
		{
			this.distributedCache = distributedCache;
		}

		public T Get<T>(string key)
		{
			string data = distributedCache.GetString(key);
			return JsonConvert.DeserializeObject<T>(data);
		}

		public void Set<T>(string key, T data)
		{
			distributedCache.SetString(key, JsonConvert.SerializeObject(data));
		}
	}
}
