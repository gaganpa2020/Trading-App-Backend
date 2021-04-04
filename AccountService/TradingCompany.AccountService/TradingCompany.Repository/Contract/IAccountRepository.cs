namespace TradingCompany.Repository
{
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface IAccountRepository
	{
		void CreateAccount(UserAccount userAccount);
		IList<UserAccount> GetAllUserAccount();
		UserAccount GetUserAccount(int AccountId);
		UserAccount GetUserAccount(string email);
	}
}