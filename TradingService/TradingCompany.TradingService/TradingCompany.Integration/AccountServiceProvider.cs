namespace TradingCompany.Integration
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class AccountServiceProvider : IAccountServiceProvider
	{
		public bool UpdateBalance(int AccountId, double amount)
		{
			// In the real world we would call the trading cache (or account service) to verify the ticker status and its price. 
			// We can use 'read through/write behind caching' to speed up this verification. 
			return true;
		}

		public bool ValidateAccountBalance(int AccountId, double amount)
		{
			// In the real world we would call the trading cache (or account service) to verify the ticker status and its price. 
			// We can use 'read through/write behind caching' to speed up this verification. 
			return true;
		}

		public bool ValidateStockOwnerShip(int AccountId, string ticker, int stockCount)
		{
			// In the real world we would call the trading cache (or account service) to verify the ticker status and its price. 
			// We can use 'read through/write behind caching' to speed up this verification. 
			return true;
		}
	}
}
