using System;

namespace TradingCompany.Models
{
	public class Stock
	{
		public string Ticker { get; set; }
		public double Amount { get; set; }
		public DateTime TimeStamp { get; set; }		
	}
}
