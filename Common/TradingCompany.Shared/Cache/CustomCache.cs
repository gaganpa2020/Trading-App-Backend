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
			T result = default(T);
			string data = distributedCache.GetString(key);
			if (data != null)
			{
				result = JsonConvert.DeserializeObject<T>(data);
			}

			return result;
		}

		public void Set<T>(string key, T data)
		{
			distributedCache.SetString(key, JsonConvert.SerializeObject(data));
		}
	}
}
