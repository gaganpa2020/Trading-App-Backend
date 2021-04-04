namespace TradingCompany.Business
{
	using TradingCompany.Models;
	using TradingCompany.Shared;

	public class RequestValidator : IRequestValidator
	{
		public bool ValidateCreditRequest(BankAccount account, BankAccountRequest request)
		{
			if (account == null || request == null)
			{
				throw new CustomException("Invalid Request, account or request is null");
			}

			if (request.Amount <= 0)
			{
				throw new CustomException("Invalid Request, amount can't be negative");
			}

			return true;
		}

		public bool ValidateDebitRequest(BankAccount account, BankAccountRequest request)
		{
			if (account == null || request == null)
			{
				throw new CustomException("Invalid Request");
			}

			if (account.AccountBalance < request.Amount)
			{
				throw new CustomException("Invalid Request, amount can't be more than balance");
			}

			return true;
		}
	}
}
