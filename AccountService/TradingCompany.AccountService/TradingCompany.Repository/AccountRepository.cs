namespace TradingCompany.Repository
{
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Models;

	public class AccountRepository : IAccountRepository
	{
		// This is a temp collection for demo purpose. 
		// In the real world we would use SQL/Cosmos to maintain this data. 
		private static readonly IList<UserAccountEntity> userAccounts = new List<UserAccountEntity>()
		{
		new UserAccountEntity(){
			AccountId=1, SSN="111-111-1111", Phone="444-443-4445", City="Philadelphia", State="PA", Email="test@gmail.com", Balance = 100
			, stocks = new Dictionary<string, int>()
			{
				{ "TSLA", 10},
				{ "MSFT", 5},
				{ "APPL", 14},
			}
		}
		};

		public void CreateAccount(UserAccountEntity userAccount)
		{
			userAccounts.Add(userAccount);
		}

		public IList<UserAccountEntity> GetAllUserAccount()
		{
			return userAccounts;
		}

		public UserAccountEntity GetUserAccount(int accountId)
		{
			return userAccounts.FirstOrDefault(x => x.AccountId == accountId);
		}

		public UserAccountEntity GetUserAccount(string email)
		{
			return userAccounts.FirstOrDefault(x => x.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));
		}

		public void UpdateBalance(int accountId, double balance)
		{
			if (userAccounts.Any(x => x.AccountId == accountId))
			{
				UserAccountEntity account = userAccounts.FirstOrDefault(x => x.AccountId == accountId);
				account.Balance += balance;
			}
		}
	}
}
