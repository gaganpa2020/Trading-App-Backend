namespace TradingCompany.UserService
{
	using Autofac;
	using TradingCompany.Repository;
	using TradingCompany.Shared;

	public static class DependencyInjection
	{
		public static void RegisterDependency(ContainerBuilder builder)
		{
			builder.RegisterType<CustomCache>().As<ICustomCache>();
			builder.RegisterType<HttpProvider>().As<IProvider>();
			builder.RegisterType<TransactionHistoryRepository>().As<ITransactionHistoryRepository>();
		}
	}
}
