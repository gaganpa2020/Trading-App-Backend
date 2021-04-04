namespace TradingCompany.Repository
{
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface IAccountRepository
	{
		void CreateAccount(UserTradingAccount userAccount);
		IList<UserTradingAccount> GetAllUserAccount();
		UserTradingAccount GetUserAccount(int AccountId);
		UserTradingAccount GetUserAccount(string email);
	}
}