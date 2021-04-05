namespace TradingCompany.Repository
{
	using System;
	using TradingCompany.Models;
	using System.Collections.Generic;

	public interface ITriggerRepository
	{
		void SetupTrigger(TradeTriggerEntity tradeTriggerEntity);
		IList<TradeTriggerEntity> Get();
		void UpdateTrigger(Guid triggerId, TriggerStatus triggerStatus);
	}
}