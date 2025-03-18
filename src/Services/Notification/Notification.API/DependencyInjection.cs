using Shared.DependencyInjection;
using Shared.Exceptions.Handler;

namespace Notification.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddExceptionHandler<GlobalExceptionHandler>();
		services.AddSqlServerHealthChecks(configuration);

		return services;
	}

	public static WebApplication UseApiServices(this WebApplication app)
	{
		app.UseExceptionHandler(options => { });
		app.UseHealthChecks();

		return app;
	}
}
