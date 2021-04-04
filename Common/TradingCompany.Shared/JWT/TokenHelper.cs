namespace TradingCompany.Shared
{
	using Microsoft.AspNetCore.Http;

	public class TokenHelper : ITokenHelper
	{
		private readonly IHttpContextAccessor accessor;

		public TokenHelper(IHttpContextAccessor accessor)
		{
			this.accessor = accessor;
		}

		public string AccessToken()
		{
			string token = accessor.HttpContext.Request.Headers["Authorization"];
			if (token.StartsWith("Bearer "))
			{
				token = token.Replace("Bearer ", string.Empty);
			}

			return token;
		}
	}
}
