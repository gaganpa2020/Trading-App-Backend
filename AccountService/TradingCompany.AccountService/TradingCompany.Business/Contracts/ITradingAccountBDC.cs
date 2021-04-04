namespace TradingCompany.Business
{
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface ITradingAccountBDC
	{
		void CreateAccount(UserTradingAccount userAccount);
		IList<UserTradingAccount> GetAllUserAccount();
	}
}