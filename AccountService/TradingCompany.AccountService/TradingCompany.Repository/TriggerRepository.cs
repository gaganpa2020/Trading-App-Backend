namespace TradingCompany.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Models;
	using TradingCompany.Shared;

	public class TriggerRepository : ITriggerRepository
	{
		private static readonly IList<TradeTriggerEntity> triggers = new List<TradeTriggerEntity>();
		public void SetupTrigger(TradeTriggerEntity tradeTriggerEntity)
		{
			triggers.Add(tradeTriggerEntity);
		}

		public IList<TradeTriggerEntity> Get()
		{
			return triggers;
		}

		public void UpdateTrigger(Guid triggerId, TriggerStatus triggerStatus)
		{
			if (triggers.Any(x => x.TriggerId == triggerId && x.Status == TriggerStatus.Active))
			{
				triggers.FirstOrDefault(x => x.TriggerId == triggerId)
					.Status = triggerStatus;
			}
			else
			{
				throw new CustomException("Invalid trigger Id to update status.");
			}
		}
	}
}
