namespace TradingCompany.Business
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using TradingCompany.Models;
	using TradingCompany.Repository;
	using TradingCompany.Shared;

	public class TradingAccountBDC : ITradingAccountBDC
	{
		private readonly IAccountRepository accountRepository;

		public TradingAccountBDC(IAccountRepository accountRepository)
		{
			this.accountRepository = accountRepository;
		}

		public void CreateAccount(UserTradingAccount userAccount)
		{
			if (string.IsNullOrWhiteSpace(userAccount.SSN)
					|| string.IsNullOrWhiteSpace(userAccount.Phone)
					|| string.IsNullOrWhiteSpace(userAccount.City)
					|| string.IsNullOrWhiteSpace(userAccount.State)
					|| string.IsNullOrWhiteSpace(userAccount.Email))
			{
				throw new CustomException("Invalid account details");
			}

			this.accountRepository.CreateAccount(new UserAccountEntity()
			{
				AccountId = userAccount.AccountId,
				Balance = userAccount.Balance,
				City = userAccount.City,
				Email = userAccount.Email,
				Phone = userAccount.Phone,
				SSN = userAccount.SSN,
				State = userAccount.State,
				stocks = new Dictionary<string, int>()
			});
		}

		public IList<UserAccountEntity> GetAllUserAccount()
		{
			return this.accountRepository.GetAllUserAccount();
		}
	}
}
