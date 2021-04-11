namespace TradingCompany.Integration
{
	using Microsoft.Extensions.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Text;
	using TradingCompany.Models;
	using TradingCompany.Shared;

	public class AccountServiceProvider : IAccountServiceProvider
	{
		private readonly IProvider httpProvider;
		private readonly ITokenHelper tokenHelper;
		private string AccountServiceBaseUrl;

		public AccountServiceProvider(IProvider httpProvider
		 , ITokenHelper tokenHelper
			, IConfiguration configuration)
		{
			this.httpProvider = httpProvider;
			this.tokenHelper = tokenHelper;
			AccountServiceBaseUrl = configuration["Services:AccountService"];
		}

		public bool UpdateBalance(int AccountId, double amount)
		{
			// In the real world we would call the trading cache (or account service) to verify the ticker status and its price. 
			// We can use 'read through/write behind caching' to speed up this verification. 
			return true;
		}

		public bool ValidateAccountBalance(int AccountId, double amount)
		{
			// In the real world we would call the trading cache (or account service) to verify the ticker status and its price. 
			// We can use 'read through/write behind caching' to speed up this verification. 
			return true;
		}

		public bool ValidateStockOwnerShip(int AccountId, string ticker, int stockCount)
		{
			// In the real world we would call the trading cache (or account service) to verify the ticker status and its price. 
			// We can use 'read through/write behind caching' to speed up this verification. 
			return true;
		}

		public void UpdateTrigger(Guid triggerId, TriggerStatus triggerStatus)
		{
			IDictionary<string, string> headers = new Dictionary<string, string>();
			/**
			*  Add Authentication headers
			*  headers.Add("Authorization", $"Bearer {tokenHelper.AccessToken()}");
			*/
			HttpResponseMessage response = httpProvider.Post<string>($"{AccountServiceBaseUrl}/Trigger/update?triggerId={triggerId}&triggerStatus={triggerStatus}", headers, string.Empty).Result;
		}
	}
}
