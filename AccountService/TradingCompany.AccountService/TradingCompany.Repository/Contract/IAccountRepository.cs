namespace TradingCompany.Repository
{
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface IAccountRepository
	{
		void CreateAccount(UserAccountEntity userAccount);
		IList<UserAccountEntity> GetAllUserAccount();
		UserAccountEntity GetUserAccount(int AccountId);
		UserAccountEntity GetUserAccount(string email);
		void UpdateBalance(int accountId, double balance);
	}
}