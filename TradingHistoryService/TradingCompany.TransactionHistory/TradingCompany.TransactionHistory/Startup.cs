using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TradingCompany.Shared;

namespace TradingCompany.UserService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(config =>
			{
				config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please insert JWT with Bearer into field",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});
				config.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
					new OpenApiSecurityScheme
					{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
					},
					new string[] { }
				}
				});
			});

			services.AddDistributedMemoryCache();
			services.AddApplicationInsightsTelemetry();
			JWTToken.SetupJWTServices(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.DocumentTitle = "User Services";
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Services");
				c.RoutePrefix = string.Empty;
			});

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			DependencyInjection.RegisterDependency(builder);
		}


	}
}
