namespace TradingCompany.Models
{
	using System;

	public class TriggerTradeModel
	{
		public Guid TriggerId { get; set; }
		public int AccountId { get; set; }
		public int UserAccountId { get; set; }
		public string Ticker { get; set; }
		public int NoOfStocks { get; set; } 
		public DateTime RequestTime { get; set; }
		public TradeType TradeType { get; set; }
		public double Price { get; set; }
	}
}
