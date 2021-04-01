namespace TradingCompany.Common
{
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Threading.Tasks;

	public interface IProvider
	{
		Task<HttpResponseMessage> Get(string url, IDictionary<string, string> headers);

		Task<HttpResponseMessage> Post<T>(string url, IDictionary<string, string> headers, T content);

		Task<HttpResponseMessage> Put<T>(string url, IDictionary<string, string> headers, T content);

		Task<HttpResponseMessage> Delete<T>(string url, IDictionary<string, string> headers);
	}
}
