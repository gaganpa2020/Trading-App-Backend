

namespace TradingCompany.TradingService
{
	using Autofac;
	using Microsoft.Azure.ServiceBus;
	using System;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using TradingCompany.Business;
	using TradingCompany.Models;

	public class AutomatedTradingManager : IAutomatedTradingManager
	{
		private QueueClient queueClient;
		private IComponentContext componentContext;

		public AutomatedTradingManager(IComponentContext componentContext)
		{
			this.componentContext = componentContext;
		}

		public void RegisterQueueSubscriber()
		{
			string connectionString = "Endpoint=sb://nagp-microservices-assignment.servicebus.windows.net/;SharedAccessKeyName=UserPolicy;SharedAccessKey=XaWt2iBzcrAoRNBKzgCJRVgS5iO1iVCFxC+2rk/5dHw=;";
			string queueName = "tradingqueue";
			var messageHandlerOptions = new MessageHandlerOptions(HandleFailureMessage)
			{
				MaxConcurrentCalls = 5,
				AutoComplete = false,
				MaxAutoRenewDuration = TimeSpan.FromMinutes(10)
			};
			queueClient = new QueueClient(connectionString, queueName);
			queueClient.RegisterMessageHandler(Handle, messageHandlerOptions);
		}

		public async Task Handle(Message message, CancellationToken cancelToken)
		{
			ITradeBDC tradeBDC = this.componentContext.Resolve<ITradeBDC>();

			if (message == null)
				throw new ArgumentNullException(nameof(message));

			string body = Encoding.UTF8.GetString(message.Body);

			TriggerTradeModel request = Newtonsoft.Json.JsonConvert.DeserializeObject<TriggerTradeModel>(body);
			tradeBDC.RunAutomatedTransaction(request);
			await queueClient.CompleteAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
		}
		public Task HandleFailureMessage(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
		{
			if (exceptionReceivedEventArgs == null)
				throw new ArgumentNullException(nameof(exceptionReceivedEventArgs));
			return Task.CompletedTask;
		}
	}
}
