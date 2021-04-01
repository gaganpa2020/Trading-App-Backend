namespace TradingCompany.Shared
{
	public interface ICustomCache
	{
		T Get<T>(string key);
		void Set<T>(string key, T data);
	}
}