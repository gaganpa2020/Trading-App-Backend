namespace TradingCompany.Repository
{
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface ITradeRepository
	{
		void CommitTrade(TradeModel tradeEntity);
		IList<TradeModel> GetTradeData();
	}
}