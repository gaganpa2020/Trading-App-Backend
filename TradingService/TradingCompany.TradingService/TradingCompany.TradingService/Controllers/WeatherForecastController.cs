namespace TradingCompany.TradingService.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using System.Collections.Generic;
	using TradingCompany.Business;
	using TradingCompany.Models;

	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class TradingController : ControllerBase
	{
		private readonly ILogger<TradingController> logger;
		private readonly ITradeBDC tradeBDC;

		public TradingController(ILogger<TradingController> logger
			, ITradeBDC tradeBDC)
		{
			this.logger = logger;
			this.tradeBDC = tradeBDC;
		}

		[HttpGet]
		public IEnumerable<TradeModel> Get()
		{
			return tradeBDC.GetAllTradeData();
		}

		[HttpPost]
		public void Post(TradeModel request)
		{
			this.tradeBDC.RunTransaction(request);
		}
	}
}
