namespace TradingCompany.Models
{
	using System;

	public class TradeTriggerRequest
	{
		public int AccountId { get; set; }
		public int BankAccountId { get; set; }
		public string Ticker { get; set; }
		public TradeType TradeType { get; set; }
		public DateTime ExpiryTimeStamp { get; set; }
		public int NoOfStocks { get; set; } //Currently this service support the no of stocks to be trade for buy/sell.
		public double PriceLimit { get; set; }
	}
}
