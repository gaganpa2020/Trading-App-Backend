namespace TradingCompany.Integration
{
	using Microsoft.Extensions.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Text;
	using TradingCompany.Models;
	using TradingCompany.Shared;

	public class TradeServiceProvider : ITradeServiceProvider
	{
		private readonly IProvider httpProvider;
		private readonly ITokenHelper tokenHelper;
		private string TradeServiceBaseUrl;

		public TradeServiceProvider(IProvider httpProvider
			, ITokenHelper tokenHelper
			, IConfiguration configuration)
		{
			this.httpProvider = httpProvider;
			this.tokenHelper = tokenHelper;
			TradeServiceBaseUrl = configuration["Services:TradingService"];
		}

		public void PopulateTradingCache(UserAccountEntity userAccountEntity)
		{
			IDictionary<string, string> headers = new Dictionary<string, string>();
			headers.Add("Authorization", $"Bearer {tokenHelper.AccessToken()}");
			HttpResponseMessage response = httpProvider.Post<UserAccountEntity>($"{TradeServiceBaseUrl}/Trading/populatecache", headers, userAccountEntity).Result;
		}
	}
}
