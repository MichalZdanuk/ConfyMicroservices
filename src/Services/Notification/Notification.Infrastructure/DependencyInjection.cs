using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Data;
using Notification.Infrastructure.Data;
using Shared.Interceptors;

namespace Notification.Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Database");

		services.AddRepositories();
		services.AddCustomInterceptors();

		services.AddDbContext<NotificationDbContext>((sp, options) =>
		{
			options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
			options.UseSqlServer(connectionString);
		});

		services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<NotificationDbContext>());

		return services;
	}

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{

		return services;
	}
}
