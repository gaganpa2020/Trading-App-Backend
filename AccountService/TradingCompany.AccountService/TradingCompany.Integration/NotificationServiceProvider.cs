namespace TradingCompany.Integration
{
	using System;

	public class NotificationServiceProvider : INotificationServiceProvider
	{
		public void SendNotification(string message)
		{
			// In the real world app, this method will add a message in a queue to be picked by notification service and
			// send message to the respective consumer. This provider can have more detailed signature. 
			Console.WriteLine("Send notification"); 
		}
	}
}
