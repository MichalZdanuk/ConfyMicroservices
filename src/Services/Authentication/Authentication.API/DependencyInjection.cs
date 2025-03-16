using Authentication.API.Services;
using Shared.DependencyInjection;

namespace Authentication.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddApplicationServices(Assembly.GetExecutingAssembly());

		services.AddScoped<ICustomAuthService, CustomAuthService>();

		return services;
	}
}
