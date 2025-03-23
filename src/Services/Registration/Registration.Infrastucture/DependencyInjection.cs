using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interceptors;
using Shared.UnitOfWork;

namespace Registration.Infrastucture;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Database");

		services.AddRepositories();
		services.AddCustomInterceptors();

		return services;
	}

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{

		return services;
	}
}
