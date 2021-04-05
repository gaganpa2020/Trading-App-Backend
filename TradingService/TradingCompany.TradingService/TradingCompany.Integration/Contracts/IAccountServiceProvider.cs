namespace TradingCompany.Integration
{
	using System;
	using TradingCompany.Models;

	public interface IAccountServiceProvider
	{
		bool ValidateAccountBalance(int AccountId, double amount);
		bool ValidateStockOwnerShip(int AccountId, string ticker, int stockCount);
		bool UpdateBalance(int AccountId, double amount);
		void UpdateTrigger(Guid triggerId, TriggerStatus triggerStatus);
	}
}