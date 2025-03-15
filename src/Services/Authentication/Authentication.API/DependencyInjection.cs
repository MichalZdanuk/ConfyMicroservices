using Authentication.API.Services;
using Shared.DependencyInjection;
using System.Reflection;

namespace Authentication.API;

public static class DependencyInjection
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddApplicationServices(Assembly.GetExecutingAssembly());

		services.AddScoped<ICustomAuthService, CustomAuthService>();

		return services;
	}
}
