using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.DependencyInjection;
public static class ApiExtensions
{
	public static IServiceCollection AddSqlServerHealthChecks(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHealthChecks()
			.AddSqlServer(configuration.GetConnectionString("Database")!);

		return services;
	}

	public static WebApplication UseHealthChecks(this WebApplication app)
	{
		app.UseHealthChecks("/health",
			new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

		return app;
	}
}
