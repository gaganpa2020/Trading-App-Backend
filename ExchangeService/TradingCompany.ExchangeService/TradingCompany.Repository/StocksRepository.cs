namespace TradingCompany.Repository
{
	using System;
	using System.Collections.Generic;
	using TradingCompany.Models;

	/// <summary>
	/// Stock Repository.
	/// In the real world this class would be fetching data from DB which is populated with live stock exchange data. 
	/// For assignment purpose we have mocked that data as hardcoded.
	/// </summary>
	/// <seealso cref="TradingCompany.Repository.IStocksRepository" />
	public class StocksRepository : IStocksRepository
	{
		private Random random = new Random();
		public IList<Stock> GetHistoricalData(string ticker)
		{
			List<Stock> stocks = new List<Stock>();

			for (int i = 180; i > 0; i--)
			{
				stocks.Add(new Stock() { Ticker = ticker, Amount = random.Next(600, 700), TimeStamp = DateTime.Now.AddDays(-i) });
			}

			return stocks;
		}

		public IList<Stock> GetLiveFeed()
		{
			return new List<Stock>()
			{
				new Stock(){  Ticker="TSLA", Amount= random.Next(600, 700), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="MSFT", Amount=random.Next(200, 250), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="RMO", Amount=random.Next(10, 20), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="BNGO", Amount=random.Next(10, 30), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="QS", Amount=random.Next(10, 14), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="MDRN", Amount=random.Next(1, 19), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="APPL", Amount=random.Next(120, 140), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="HVLP", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="CVS", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="WM", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="RT", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="CEO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="RRO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="RRO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="EEO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="EMO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="GGMO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="RGGO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="RMGG", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="RMWW", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="WWO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="EEMO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="EEMO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="EEMO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now},
				new Stock(){  Ticker="EEMO", Amount=random.Next(10, 100), TimeStamp= DateTime.Now}
			};
		}
	}
}
