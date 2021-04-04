namespace TradingCompany.Integration
{
	public interface IExchangeServiceProvider
	{
		public bool ValidateStock(string ticker, double price);
	}
}