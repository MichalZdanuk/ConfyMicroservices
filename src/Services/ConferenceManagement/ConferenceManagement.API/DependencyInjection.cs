using Shared.DependencyInjection;

namespace ConferenceManagement.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSqlServerHealthChecks(configuration);

		return services;
	}

	public static WebApplication UseApiServices(this WebApplication app)
	{
		app.UseHealthChecks();

		return app;
	}
}
