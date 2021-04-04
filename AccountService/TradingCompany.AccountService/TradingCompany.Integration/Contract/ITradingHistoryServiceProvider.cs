namespace TradingCompany.Integration
{
	using TradingCompany.Models;

	public interface ITradingHistoryServiceProvider
	{
		void AddBankTransactionEvent(BankAccountRequest request);
	}
}