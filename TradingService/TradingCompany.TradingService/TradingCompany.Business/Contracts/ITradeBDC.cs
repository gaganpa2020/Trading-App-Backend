namespace TradingCompany.Business
{
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface ITradeBDC
	{
		void RunTransaction(TradeModel tradeRequest);
		IList<TradeModel> GetAllTradeData();
	}
}