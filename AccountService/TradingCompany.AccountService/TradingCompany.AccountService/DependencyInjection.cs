namespace TradingCompany.AccountService
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
			// Shared
			builder.RegisterType<CustomCache>().As<ICustomCache>();
			builder.RegisterType<HttpProvider>().As<IProvider>();
			builder.RegisterType<TokenHelper>().As<ITokenHelper>();

			// TradingCompany.Business
			builder.RegisterType<BankAccountBDC>().As<IBankAccountBDC>();
			builder.RegisterType<TradingAccountBDC>().As<ITradingAccountBDC>();
			builder.RegisterType<RequestValidator>().As<IRequestValidator>();
			builder.RegisterType<TriggerBDC>().As<ITriggerBDC>();

			// TradingCompany.Integration
			builder.RegisterType<NotificationServiceProvider>().As<INotificationServiceProvider>();
			builder.RegisterType<MockPaymentGateway>().As<IPaymentGateway>();
			builder.RegisterType<TradingHistoryServiceProvider>().As<ITradingHistoryServiceProvider>();
			builder.RegisterType<TradeServiceProvider>().As<ITradeServiceProvider>();

			// TradingCompany.Repository
			builder.RegisterType<AccountRepository>().As<IAccountRepository>();
			builder.RegisterType<BankAccountRepository>().As<IBankAccountRepository>();
			builder.RegisterType<TriggerRepository>().As<ITriggerRepository>();
		}
	}
}
