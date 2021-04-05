namespace TradingCompany.Business
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Threading.Tasks;
	using TradingCompany.Integration;
	using TradingCompany.Models;
	using TradingCompany.Repository;

	public class TriggerBDC : ITriggerBDC
	{
		private readonly ITriggerRepository triggerRepository;
		private readonly ITradeServiceProvider tradeServiceProvider;
		private readonly IAccountRepository accountRepository;

		public TriggerBDC(ITriggerRepository triggerRepository
			, ITradeServiceProvider tradeServiceProvider
			, IAccountRepository accountRepository)
		{
			this.triggerRepository = triggerRepository;
			this.tradeServiceProvider = tradeServiceProvider;
			this.accountRepository = accountRepository;
		}

		public IList<TradeTriggerEntity> Get()
		{
			return this.triggerRepository.Get();
		}

		public void SetupTrigger(TradeTriggerRequest tradeTriggerRequest)
		{
			/**
			 * Set of varification steps would be required in the real world.
			 * Verify If user have enough balance to full fill buy request.
			 * Verify If user have enough stocks to full fill sell request.
			 */

			this.triggerRepository.SetupTrigger(new TradeTriggerEntity()
			{
				TriggerId = Guid.NewGuid(),
				Status = TriggerStatus.Active,
				AccountId = tradeTriggerRequest.AccountId,
				BankAccountId = tradeTriggerRequest.BankAccountId,
				NoOfStocks = tradeTriggerRequest.NoOfStocks,
				Ticker = tradeTriggerRequest.Ticker,
				TradeType = tradeTriggerRequest.TradeType,
				ExpiryTimeStamp = tradeTriggerRequest.ExpiryTimeStamp
			});

			new Task(() =>
			{
				UserAccountEntity account = accountRepository.GetUserAccount(tradeTriggerRequest.AccountId);
				this.tradeServiceProvider.PopulateTradingCache(account); //Populate trading service cache. 
			}).Start();

		}

		public void UpdateTrigger(Guid triggerId, TriggerStatus triggerStatus)
		{
			this.triggerRepository.UpdateTrigger(triggerId, triggerStatus);
		}
	}
}
