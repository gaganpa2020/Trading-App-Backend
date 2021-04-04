using TradingCompany.Models;

namespace TradingCompany.Integration
{
	public interface ITradeHistoryServiceProvider
	{
		void RegisterTrade(TradeModel tradeRequest);
	}
}