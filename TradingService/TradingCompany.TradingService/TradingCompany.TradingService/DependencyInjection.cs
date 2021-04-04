namespace TradingCompany.TradingService
{
	using Autofac;
	using TradingCompany.Business;
	using TradingCompany.Integration;
	using TradingCompany.Repository;
	using TradingCompany.Shared;

	public static class DependencyInjection
	{
		public static void RegisterDependency(ContainerBuilder builder)
		{
			// TradingCompany.Shared
			builder.RegisterType<CustomCache>().As<ICustomCache>();
			builder.RegisterType<HttpProvider>().As<IProvider>();

			// TradingCompany.Business
			builder.RegisterType<TradeBDC>().As<ITradeBDC>();

			// TradingCompany.Integration
			builder.RegisterType<AccountServiceProvider>().As<IAccountServiceProvider>();
			builder.RegisterType<ExchangeServiceProvider>().As<IExchangeServiceProvider>();
			builder.RegisterType<NotificationServiceProvider>().As<INotificationServiceProvider>();
			builder.RegisterType<TradeHistoryServiceProvider>().As<ITradeHistoryServiceProvider>();

			// TradingCompany.Repository
			builder.RegisterType<TradeRepository>().As<ITradeRepository>();
		}
	}
}
