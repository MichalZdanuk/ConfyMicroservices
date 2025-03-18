using Microsoft.Extensions.DependencyInjection;
using Shared.Behaviors;
using System.Reflection;

namespace ConferenceManagement.Application;
public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			config.AddOpenBehavior(typeof(LoggingBehavior<,>));
		});

		return services;
	}
}
