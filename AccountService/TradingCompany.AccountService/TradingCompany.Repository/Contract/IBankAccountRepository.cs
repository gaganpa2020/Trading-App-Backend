using System.Collections.Generic;
using TradingCompany.Models;

namespace TradingCompany.Repository
{
	public interface IBankAccountRepository
	{
		void LinkMyBankAccount(BankAccount bankAccount);
		BankAccount GetBankAccount(int bankAccountId);
		IList<BankAccount> GetAllBankAccounts();
		void AddMoney(BankAccountRequest request);
		void WithdrawMoeny(BankAccountRequest request);
	}
}