

namespace TradingCompany.TradingService
{
	using Autofac;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Azure.ServiceBus;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.OpenApi.Models;
	using System;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using TradingCompany.Business;
	using TradingCompany.Integration;
	using TradingCompany.Models;
	using TradingCompany.Repository;
	using TradingCompany.Shared;

	public class AutomatedTradingManager
	{
		private QueueClient queueClient;
		private ContainerBuilder builder;

		public AutomatedTradingManager(ContainerBuilder builder)
		{
			this.builder = builder;
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
			ITradeBDC tradeBDC = builder.Build().Resolve<ITradeBDC>();

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
