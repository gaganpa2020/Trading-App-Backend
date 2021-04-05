using System;
using System.Collections.Generic;
using System.Text;
using TradingCompany.Models;
using TradingCompany.Shared;

namespace TradingCompany.Integration
{
	public class TradeHistoryServiceProvider: ITradeHistoryServiceProvider
	{
		public void RegisterTrade(TradeModel tradeRequest)
		{
			//In the real world we would call the trade history service  to register trade records. 
			Console.WriteLine("trade registered in store.");
		}
	}
}
