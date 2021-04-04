using System;
using TradingCompany.Shared;

namespace TradingCompany.Integration
{
	public class ExchangeServiceProvider : IExchangeServiceProvider
	{
		private readonly IProvider httpProvider;

		public ExchangeServiceProvider(IProvider provider)
		{
			this.httpProvider = provider;
		}

		public bool ValidateStock(string ticker, double price)
		{
			// In the real world we would call the exchange service to verify the ticker status and its price. 
			// We can use 'read through/write behind caching' to speed up this verification. 
			return true;
		}
	}
}
