namespace TradingCompany.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Models;

	public class BankAccountRepository : IBankAccountRepository
	{
		private static readonly IList<BankAccount> bankAccounts = new List<BankAccount>()
		{
			new BankAccount(){ BankAccountId=1, CustomerName="Rangeela", AccountNumber="4544-4456-9911", RoutingNumber="333222", AccountBalance=100  }
		};

		public void LinkMyBankAccount(BankAccount bankAccount)
		{
			bankAccounts.Add(bankAccount);
		}

		public BankAccount GetBankAccount(int bankAccountId)
		{
			return bankAccounts.FirstOrDefault(x => x.BankAccountId == bankAccountId);
		}

		public IList<BankAccount> GetAllBankAccounts()
		{
			return bankAccounts;
		}

		public void AddMoney(BankAccountRequest request)
		{
			BankAccount account = bankAccounts.FirstOrDefault(x => x.BankAccountId == request.BankAccountId);
			account.AccountBalance += request.Amount;
		}

		public void WithdrawMoeny(BankAccountRequest request)
		{
			BankAccount account = bankAccounts.FirstOrDefault(x => x.BankAccountId == request.BankAccountId);
			account.AccountBalance -= request.Amount;
		}
	}
}
