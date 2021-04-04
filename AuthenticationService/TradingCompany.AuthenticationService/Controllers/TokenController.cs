namespace TradingCompany.AuthenticationService.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using System;
	using System.Collections.Generic;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;

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
	}
}
