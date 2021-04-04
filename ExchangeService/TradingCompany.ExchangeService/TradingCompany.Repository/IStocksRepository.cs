using System.Collections.Generic;
using TradingCompany.Models;

namespace TradingCompany.Repository
{
	public interface IStocksRepository
	{
		IList<Stock> GetHistoricalData(string ticker);
		IList<Stock> GetLiveFeed();
	}
}