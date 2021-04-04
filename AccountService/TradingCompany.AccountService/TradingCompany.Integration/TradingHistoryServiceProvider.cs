namespace TradingCompany.Integration
{
	using System;
	using TradingCompany.Models;

	public class TradingHistoryServiceProvider : ITradingHistoryServiceProvider
	{
		public void AddBankTransactionEvent(BankAccountRequest request)
		{
			// In the real world, we would add an event for the Transaction history service to see any transaction on the account. 
			// Transaction history service will save all the event using event sourcing pattern & will create materialized view for the users to
			// check any transaction history in between. 
			Console.WriteLine();
		}
	}
}
