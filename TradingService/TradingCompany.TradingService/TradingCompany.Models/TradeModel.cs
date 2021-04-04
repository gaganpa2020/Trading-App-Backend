namespace TradingCompany.Models
{
	using System;

	public class TradeModel
	{
		public int UserAccountId { get; set; }
		public string Ticker { get; set; }
		public double Price { get; set; }
		public int StockCount { get; set; } // We can different models for buy/sell request. for sample we are using single model.
		public DateTime RequestTime { get; set; }
		public TradeType TradeType { get; set; }
	}
}
