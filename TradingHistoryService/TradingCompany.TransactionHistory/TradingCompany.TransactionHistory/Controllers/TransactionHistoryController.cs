namespace TradingCompany.UserService.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using System.Collections.Generic;
	using TradingCompany.Models;
	using TradingCompany.Repository;

	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class TransactionHistoryController : ControllerBase
	{
		private readonly ILogger<TransactionHistoryController> logger;
		private readonly ITransactionHistoryRepository transactionHistoryRepository;

		public TransactionHistoryController(ILogger<TransactionHistoryController> logger
			, ITransactionHistoryRepository transactionHistoryRepository)
		{
			this.logger = logger;
			this.transactionHistoryRepository = transactionHistoryRepository;
		}

		[HttpGet]
		public IEnumerable<TransactionHistory> Get()
		{
			return transactionHistoryRepository.Get();
		}
	}
}
