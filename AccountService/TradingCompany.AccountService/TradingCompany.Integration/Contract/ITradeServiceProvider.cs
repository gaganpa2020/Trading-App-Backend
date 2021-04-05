using TradingCompany.Models;

namespace TradingCompany.Integration
{
	public interface ITradeServiceProvider
	{
		public void PopulateTradingCache(UserAccountEntity userAccountEntity);
	}
}