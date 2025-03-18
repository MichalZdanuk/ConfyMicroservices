using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Interceptors;

namespace Authentication.API.DAL;

public static class Extensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Database");

		services.AddCustomInterceptors();

		services.AddDbContext<AuthenticationDbContext>((sp, options) =>
		{
			options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
			options.UseSqlServer(connectionString);
		});

		return services;
	}
}
