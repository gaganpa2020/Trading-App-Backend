namespace TradingCompany.Shared
{
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.IdentityModel.Tokens;
	using System;
	using System.Text;
	using System.Threading.Tasks;

	public static class JWTToken
	{
		public static void SetupJWTServices(IServiceCollection services)
		{
			string key = "test_-secret-_key";
			var issuer = "http://test.com";

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		  .AddJwtBearer(options =>
		  {
			  options.TokenValidationParameters = new TokenValidationParameters
			  {
				  ValidateIssuer = true,
				  ValidateAudience = true,
				  ValidateIssuerSigningKey = true,
				  ValidIssuer = issuer,
				  ValidAudience = issuer,
				  ValidateLifetime = true,
				  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
				  ClockSkew = TimeSpan.Zero
			  };

			  options.Events = new JwtBearerEvents
			  {
				  OnAuthenticationFailed = context =>
				  {
					  if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
					  {
						  context.Response.Headers.Add("Token-Expired", "true");
					  }
					  return Task.CompletedTask;
				  }
			  };
		  });
		}
	}
}
