namespace TradingCompany.Shared
{
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Threading.Tasks;
	using Polly;
	using Polly.CircuitBreaker;
	using Newtonsoft.Json;
	using System.Net.Http.Headers;

	public class HttpProvider : IProvider
	{
		private readonly int RETRY_COUNT = 3;  // Note to reviewers - For more robust solution this can be read from config. 
		private readonly int EXCEPTION_COUNT = 5;
		private readonly HttpClient httpClient;
		private readonly AsyncCircuitBreakerPolicy circuitBreakerPolicy;

		public HttpProvider()
		{
			HttpClientHandler clientHandler = new HttpClientHandler();
			clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

			// Pass the handler to httpclient(from you are calling api)
			this.httpClient = new HttpClient(clientHandler);

			circuitBreakerPolicy = Policy.Handle<Exception>()
			   .CircuitBreakerAsync(EXCEPTION_COUNT, TimeSpan.FromMinutes(1),
			   (ex, t) =>
			   {
				   Console.WriteLine("Circuit is broken! No more API calls are allowed.");
			   },
			   () =>
			   {
				   Console.WriteLine("Circuit Reset! Good to go.");
			   });
		}


		public async Task<HttpResponseMessage> Get(string url, IDictionary<string, string> headers)
		{
			AddHeaders(headers);

			return await Policy
				.Handle<Exception>() // Note to reviewers - This could be a specific type of exception, for example if we want to retry just for AuthenticationException. 
				.RetryAsync(RETRY_COUNT)
				.WrapAsync(circuitBreakerPolicy)
				.ExecuteAsync(async () => await httpClient.GetAsync(url))
				.ConfigureAwait(false);
		}

		public async Task<HttpResponseMessage> Post<T>(string url, IDictionary<string, string> headers, T content)
		{
			HttpContent requestContent = new StringContent(JsonConvert.SerializeObject(content));
			requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			AddHeaders(headers);
			httpClient.DefaultRequestHeaders
					  .Accept
					  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return await Policy
				.Handle<Exception>()
				.RetryAsync(RETRY_COUNT)
				.WrapAsync(circuitBreakerPolicy)
				.ExecuteAsync(async () => await httpClient.PostAsync(url, requestContent))
				.ConfigureAwait(false);
		}

		public Task<HttpResponseMessage> Put<T>(string url, IDictionary<string, string> headers, T content)
		{
			throw new NotImplementedException();
		}

		public Task<HttpResponseMessage> Delete<T>(string url, IDictionary<string, string> headers)
		{
			throw new NotImplementedException();
		}

		private void AddHeaders(IDictionary<string, string> headers)
		{
			this.httpClient.DefaultRequestHeaders.Clear();

			if (headers != null || headers.Count > 0)
			{
				foreach (var item in headers)
				{
					this.httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
				}
			}
		}
	}
}
