namespace TradingCompany.Repository
{
	using System;
	using System.Collections.Generic;
	using TradingCompany.Models;

	public class TradeRepository : ITradeRepository
	{
		private static IList<TradeModel> tradeEntities = new List<TradeModel>();

		public void CommitTrade(TradeModel tradeEntity)
		{
			tradeEntities.Add(tradeEntity);
		}

		public IList<TradeModel> GetTradeData()
		{
			return tradeEntities;
		}
	}
}
