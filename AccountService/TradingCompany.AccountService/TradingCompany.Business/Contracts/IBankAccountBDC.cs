namespace TradingCompany.Business
{
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface IBankAccountBDC
	{
		void LinkBankAccount(BankAccount bankAccount);
		bool RunTransaction(BankAccountRequest request);
		IList<BankAccount> GetBankAccounts();
	}
}