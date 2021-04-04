namespace TradingCompany.ExchangeService
{
	using Autofac;
	using TradingCompany.Repository;
	using TradingCompany.Shared;

	public static class DependencyInjection
	{
		public static void RegisterDependency(ContainerBuilder builder)
		{
			// TradingCompany.Shared
			builder.RegisterType<CustomCache>().As<ICustomCache>();
			builder.RegisterType<HttpProvider>().As<IProvider>();

			// TradingCompany.Repository
			builder.RegisterType<StocksRepository>().As<IStocksRepository>();

		}
	}
}
