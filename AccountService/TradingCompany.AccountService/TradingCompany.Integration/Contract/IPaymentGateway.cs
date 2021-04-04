namespace TradingCompany.Integration
{
	public interface IPaymentGateway
	{
		bool ValidateBandAccountDetails(string AccountNumber, string RoutingNo, string Name);
	}
}