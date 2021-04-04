namespace TradingCompany.Models
{
	using System;

	public class TransactionHistory
	{
		public int AccountId { get; set; }
		public string TransactionType { get; set; }
		public double Amount { get; set; }
		public DateTime DatetimeStamp { get; set; }
		public string Source { get; set; }
	}
}
