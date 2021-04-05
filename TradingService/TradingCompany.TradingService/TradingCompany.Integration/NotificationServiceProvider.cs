using System;
using System.Collections.Generic;
using System.Text;
using TradingCompany.Shared;

namespace TradingCompany.Integration
{
	public class NotificationServiceProvider: INotificationServiceProvider
	{
		public void SendNotification(string message)
		{
			// In the real world app, this method will add a message in a queue to be picked by notification service and
			// send message to the respective consumer. This provider can have more detailed signature. 
			Console.WriteLine("Send notification");
		}
	}
}
