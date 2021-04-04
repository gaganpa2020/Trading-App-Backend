namespace TradingCompany.Integration
{
	public interface IAccountServiceProvider
	{
		bool ValidateAccountBalance(int AccountId, double amount);
		bool ValidateStockOwnerShip(int AccountId, string ticker, int stockCount);
		bool UpdateBalance(int AccountId, double amount);
	}
}