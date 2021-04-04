namespace TradingCompany.Repository
{
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface ITransactionHistoryRepository
	{
		IList<TransactionHistory> Get();
	}
}