
namespace TradingCompany.Business
{
	using System;
	using System.Collections.Generic;
	using TradingCompany.Models;

	public interface ITriggerBDC
	{
		void SetupTrigger(TradeTriggerRequest tradeTriggerRequest);
		IList<TradeTriggerEntity> Get();
		void UpdateTrigger(Guid triggerId, TriggerStatus triggerStatus);
	}
}