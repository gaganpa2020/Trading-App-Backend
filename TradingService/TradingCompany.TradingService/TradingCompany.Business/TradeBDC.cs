namespace TradingCompany.Business
{
	using System.Collections.Generic;
	using TradingCompany.Integration;
	using TradingCompany.Models;
	using TradingCompany.Repository;
	using TradingCompany.Shared;

	public class TradeBDC : ITradeBDC
	{
		private readonly ITradeRepository tradeRepository;
		private readonly IExchangeServiceProvider exchangeServiceProvider;
		private readonly INotificationServiceProvider notificationServiceProvider;
		private readonly ITradeHistoryServiceProvider tradeHistoryServiceProvider;
		private readonly IAccountServiceProvider accountServiceProvider;

		public TradeBDC(ITradeRepository tradeRepository
			, IExchangeServiceProvider exchangeServiceProvider
			, INotificationServiceProvider notificationServiceProvider
			, ITradeHistoryServiceProvider tradeHistoryServiceProvider
			, IAccountServiceProvider accountServiceProvider)
		{
			this.tradeRepository = tradeRepository;
			this.exchangeServiceProvider = exchangeServiceProvider;
			this.notificationServiceProvider = notificationServiceProvider;
			this.tradeHistoryServiceProvider = tradeHistoryServiceProvider;
			this.accountServiceProvider = accountServiceProvider;
		}

		public IList<TradeModel> GetAllTradeData()
		{
			return this.tradeRepository.GetTradeData();
		}

		public void RunTransaction(TradeModel tradeRequest)
		{
			if (!exchangeServiceProvider.ValidateStock(tradeRequest.Ticker, tradeRequest.Price))
			{
				throw new CustomException("Invalid ticker/price send for transaction");
			}

			if (tradeRequest.TradeType == TradeType.Buy
				&& this.accountServiceProvider.ValidateAccountBalance(tradeRequest.UserAccountId, tradeRequest.Price))
			{
				CommitTrade(tradeRequest);
				this.notificationServiceProvider.SendNotification($"Buy request for {tradeRequest.Ticker} is completed for price {tradeRequest.Price}");
			}
			else if (tradeRequest.TradeType == TradeType.Sell
				&& this.accountServiceProvider.ValidateStockOwnerShip(tradeRequest.UserAccountId, tradeRequest.Ticker, tradeRequest.StockCount))
			{
				CommitTrade(tradeRequest);
				this.notificationServiceProvider.SendNotification($"Sell request for {tradeRequest.Ticker} is completed for no of shares {tradeRequest.StockCount}");
			}
		}

		public void RunAutomatedTransaction(TriggerTradeModel tradeRequest)
		{
			/*
			 * Validation using "TradingCache" to verify automated trade requerst. 
			 */

			RunTransaction(new TradeModel()
			{
				UserAccountId = tradeRequest.UserAccountId,
				RequestTime = tradeRequest.RequestTime,
				StockCount = tradeRequest.NoOfStocks,
				Ticker = tradeRequest.Ticker,
				TradeType = tradeRequest.TradeType,
				Price = tradeRequest.Price
			});
			this.accountServiceProvider.UpdateTrigger(tradeRequest.TriggerId, TriggerStatus.Completed);
			this.notificationServiceProvider.SendNotification("Trigger executed!");
		}

		private void CommitTrade(TradeModel tradeRequest)
		{
			tradeRepository.CommitTrade(tradeRequest);
			this.accountServiceProvider.UpdateBalance(tradeRequest.UserAccountId, tradeRequest.Price);
			this.tradeHistoryServiceProvider.RegisterTrade(tradeRequest);
		}
	}
}
