namespace TradingCompany.ExchangeService.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Models;
	using TradingCompany.Repository;

	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class StockExchangeController : ControllerBase
	{
		private readonly ILogger<StockExchangeController> logger;
		private readonly IStocksRepository stocksRepository;

		public StockExchangeController(ILogger<StockExchangeController> logger
			, IStocksRepository stocksRepository)
		{
			this.logger = logger;
			this.stocksRepository = stocksRepository;
		}

		[HttpGet]
		public IEnumerable<Stock> Get()
		{
			return stocksRepository.GetLiveFeed();
		}

		[HttpGet]
		[Route("ticker")]
		public IEnumerable<Stock> GetTicker(string ticker)
		{
			return stocksRepository.GetHistoricalData(ticker);
		}
	}
}