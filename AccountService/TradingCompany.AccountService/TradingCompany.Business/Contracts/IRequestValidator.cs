namespace TradingCompany.Business
{
	using TradingCompany.Models;

	public interface IRequestValidator
	{
		bool ValidateCreditRequest(BankAccount account, BankAccountRequest request);
		bool ValidateDebitRequest(BankAccount account, BankAccountRequest request);
	}
}