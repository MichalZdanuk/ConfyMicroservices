using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.EventHandlers.Integration;
using Notification.Domain.Repositories;
using Notification.Infrastructure.Data;
using Notification.Infrastructure.Repositories;
using Shared.Interceptors;
using Shared.Messaging.MassTransit;
using Shared.UnitOfWork;

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

		services.AddScoped<IUnitOfWork, NotificationUnitOfWork>();

		var notificationApplicationAssembly = typeof(UserRegisteredEventHandler).Assembly;
		services.AddMessageBroker<NotificationDbContext>(configuration, NotificationMicroservice.MicroserviceName, notificationApplicationAssembly);

		return services;
	}

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();

		return services;
	}
}
