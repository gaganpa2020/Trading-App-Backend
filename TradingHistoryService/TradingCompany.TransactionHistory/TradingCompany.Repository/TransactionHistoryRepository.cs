namespace TradingCompany.Repository
{
	using System;
	using System.Collections.Generic;
	using TradingCompany.Models;

	public class TransactionHistoryRepository : ITransactionHistoryRepository
	{
		/// <summary>
		/// In real work this method would get the Materialized view from the even store.
		/// For assignment purpose this data is being mocked. 
		/// </summary>
		/// <returns></returns>
		public IList<TransactionHistory> Get()
		{
			return new List<TransactionHistory>()
			{
				new TransactionHistory(){ AccountId=1, Amount=40, DatetimeStamp= DateTime.Now.AddDays(-10), TransactionType="Buy", Source="User Initiated" },
				new TransactionHistory(){ AccountId=1, Amount=420, DatetimeStamp= DateTime.Now.AddDays(-11), TransactionType="Buy", Source="User Initiated" },
				new TransactionHistory(){ AccountId=1, Amount=20, DatetimeStamp= DateTime.Now.AddDays(-12), TransactionType="Sell", Source="User Initiated" },
				new TransactionHistory(){ AccountId=1, Amount=1320, DatetimeStamp= DateTime.Now.AddDays(-19), TransactionType="Sell", Source="User Initiated" },
				new TransactionHistory(){ AccountId=1, Amount=99, DatetimeStamp= DateTime.Now.AddDays(-119), TransactionType="Sell", Source="Automated" },
				new TransactionHistory(){ AccountId=2, Amount=500, DatetimeStamp= DateTime.Now.AddDays(-19), TransactionType="Bank Credit", Source="User Initiated" },
				new TransactionHistory(){ AccountId=2, Amount=300, DatetimeStamp= DateTime.Now.AddDays(-19), TransactionType="Bank Debit", Source="User Initiated" },
				new TransactionHistory(){ AccountId=1, Amount=40, DatetimeStamp= DateTime.Now.AddDays(-10), TransactionType="Buy", Source="Automated" }
			};
		}
	}
}
