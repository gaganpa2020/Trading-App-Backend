namespace TradingCompany.Repository
{
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Models;

	public class AccountRepository : IAccountRepository
	{
		// This is a temp collection for demo purpose. 
		// In the real world we would use SQL/Cosmos to maintain this data. 
		private static readonly IList<UserAccount> userAccounts = new List<UserAccount>();

		public void CreateAccount(UserAccount userAccount)
		{
			userAccounts.Add(userAccount);
		}

		public IList<UserAccount> GetAllUserAccount()
		{
			return userAccounts;
		}

		public UserAccount GetUserAccount(int AccountId)
		{
			return userAccounts.FirstOrDefault(x => x.AccountId == AccountId);
		}

		public UserAccount GetUserAccount(string email)
		{
			return userAccounts.FirstOrDefault(x => x.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));
		}
	}
}
