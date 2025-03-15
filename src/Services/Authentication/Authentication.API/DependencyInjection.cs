using Authentication.API.Services;
using System.Reflection;

namespace Authentication.API;

public static class DependencyInjection
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		services.AddScoped<ICustomAuthService, CustomAuthService>();

		return services;
	}
}
