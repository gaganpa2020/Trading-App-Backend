
using System;

namespace TradingCompany.Integration
{
	public class MockPaymentGateway : IPaymentGateway
	{
		public bool ValidateBandAccountDetails(string AccountNumber, string RoutingNo, string Name)
		{
			// Call the service for bank validation. 
			// User should get popup to enter user/password. 
			// Account should be validated. 

			return true;
		}
	}
}
