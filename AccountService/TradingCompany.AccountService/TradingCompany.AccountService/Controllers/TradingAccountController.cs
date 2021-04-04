namespace TradingCompany.AccountService.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Business;
	using TradingCompany.Models;

	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class TradingAccountController : ControllerBase
	{
		private readonly ILogger<TradingAccountController> logger;
		private readonly ITradingAccountBDC tradingAccountBDC;

		public TradingAccountController(ILogger<TradingAccountController> logger,
			ITradingAccountBDC tradingAccountBDC)
		{
			this.logger = logger;
			this.tradingAccountBDC = tradingAccountBDC;
		}

		[HttpGet]
		public IEnumerable<UserTradingAccount> Get()
		{
			return tradingAccountBDC.GetAllUserAccount();
		}

		[HttpPost]
		public void Post(UserTradingAccount account)
		{
			//Add some validations. 
			tradingAccountBDC.CreateAccount(account);
		}
	}
}
