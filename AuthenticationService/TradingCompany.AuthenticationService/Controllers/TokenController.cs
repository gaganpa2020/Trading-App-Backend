namespace TradingCompany.AuthenticationService.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Security.Cryptography;
	using System.Text;
	using System.Web;

	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		[HttpPost("gettoken")]
		public dynamic GetToken(AuthenticationModel model)
		{
			if (model.Username == "admin" && model.Password == "admin")
			{
				string key = "test_-secret-_key";
				var issuer = "http://test.com";

				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
				var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

				var permClaims = new List<Claim>();
				permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
				permClaims.Add(new Claim("userid", "1"));
				permClaims.Add(new Claim("name", "Test name"));

				var token = new JwtSecurityToken(issuer, issuer, permClaims, expires: DateTime.Now.AddDays(30), signingCredentials: credentials);
				var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
				return new { token = jwt_token };
			}
			else
			{
				return new UnauthorizedResult();
			}
		}

		[HttpGet("getsastoken")]
		public dynamic GetSASToken()
		{
			string resourceUri = "https://nagp-microservices-assignment.servicebus.windows.net";
			string keyName = "UserPolicy";
			string key = "XaWt2iBzcrAoRNBKzgCJRVgS5iO1iVCFxC+2rk/5dHw=";

			TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
			var week = 60 * 60 * 24 * 7;
			var expiry = Convert.ToString((int)sinceEpoch.TotalSeconds + week);
			string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
			HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
			var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
			var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, keyName);
			return new { sastoken = sasToken };
		}
	}
}
