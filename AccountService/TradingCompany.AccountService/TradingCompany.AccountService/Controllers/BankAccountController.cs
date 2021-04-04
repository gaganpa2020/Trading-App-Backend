namespace TradingCompany.AccountService.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using TradingCompany.Business;
	using TradingCompany.Models;

	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class BankAccountController : ControllerBase
	{
		private readonly ILogger<BankAccountController> logger;
		private readonly IBankAccountBDC bankAccountBDC;

		public BankAccountController(ILogger<BankAccountController> logger
			, IBankAccountBDC bankAccountBDC)
		{
			this.logger = logger;
			this.bankAccountBDC = bankAccountBDC;
		}

		[HttpGet]
		public IEnumerable<BankAccount> Get()
		{
			return bankAccountBDC.GetBankAccounts();
		}

		[HttpPost]
		[Route("link")]
		public void Post(BankAccount bankAccount)
		{
			 bankAccountBDC.LinkBankAccount(bankAccount);
		}


		[HttpPost]
		[Route("transaction")]
		public void Post(BankAccountRequest request)
		{
			 bankAccountBDC.RunTransaction(request);
		}
	}
}
