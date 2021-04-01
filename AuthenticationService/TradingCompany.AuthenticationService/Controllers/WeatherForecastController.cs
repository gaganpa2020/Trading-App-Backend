namespace TradingCompany.AuthenticationService.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Distributed;
	using Microsoft.Extensions.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Shared;

	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ICustomCache distributedCache;
		private readonly IProvider provider;
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger
			, ICustomCache distributedCache
			, IProvider provider)
		{
			this.logger = logger;
			this.distributedCache = distributedCache;
			this.provider = provider;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{

			if (distributedCache.Get<string>("test-key") == null)
			{
				distributedCache.Set("test-key", "Hello World!");
			}

			var test = distributedCache.Get<string>("test-key");

			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
