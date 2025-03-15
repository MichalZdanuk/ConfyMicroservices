using Microsoft.Extensions.DependencyInjection;
using Shared.Behaviors;
using System.Reflection;

namespace Shared.DependencyInjection;
public static class ApplicationExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services, Assembly assembly)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssembly(assembly);
			config.AddOpenBehavior(typeof(LoggingBehavior<,>));
		});

		return services;
	}
}
