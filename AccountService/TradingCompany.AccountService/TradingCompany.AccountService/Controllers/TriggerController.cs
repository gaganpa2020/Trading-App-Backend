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
	public class TriggerController : ControllerBase
	{
		private readonly ILogger<TriggerController> logger;
		private readonly ITriggerBDC triggerBDC;

		public TriggerController(ILogger<TriggerController> logger,
			ITriggerBDC triggerBDC)
		{
			this.logger = logger;
			this.triggerBDC = triggerBDC;
		}

		[HttpGet]
		public IEnumerable<TradeTriggerEntity> Get()
		{
			return triggerBDC.Get();
		}

		[HttpPost]
		public void Post(TradeTriggerRequest request)
		{
			triggerBDC.SetupTrigger(request);
		}

		[HttpPost("update")]
		public void UpdateTrigger(Guid triggerId, TriggerStatus triggerStatus)
		{
			//Add some validations. 
			triggerBDC.UpdateTrigger(triggerId, triggerStatus);
		}
	}
}
