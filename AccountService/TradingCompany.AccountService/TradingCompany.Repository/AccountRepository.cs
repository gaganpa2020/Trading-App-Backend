namespace TradingCompany.Repository
{
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Models;

	public class AccountRepository : IAccountRepository
	{
		// This is a temp collection for demo purpose. 
		// In the real world we would use SQL/Cosmos to maintain this data. 
		private static readonly IList<UserTradingAccount> userAccounts = new List<UserTradingAccount>()
		{
		new UserTradingAccount(){ AccountId=1, SSN="111-111-1111", Phone="444-443-4445", City="Philadelphia", State="PA", Email="test@gmail.com" }
		};

		public void CreateAccount(UserTradingAccount userAccount)
		{
			userAccounts.Add(userAccount);
		}

		public IList<UserTradingAccount> GetAllUserAccount()
		{
			return userAccounts;
		}

		public UserTradingAccount GetUserAccount(int AccountId)
		{
			return userAccounts.FirstOrDefault(x => x.AccountId == AccountId);
		}

		public UserTradingAccount GetUserAccount(string email)
		{
			return userAccounts.FirstOrDefault(x => x.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));
		}
	}
}
