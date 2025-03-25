using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Application.EventHandlers.Integration;
using Registration.Domain.Repositories;
using Registration.Infrastucture.Repositories;
using Shared.Interceptors;
using Shared.Messaging.MassTransit;
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

		services.AddDbContext<RegistrationDbContext>((sp, options) =>
		{
			options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
			options.UseSqlServer(connectionString);
		});

		services.AddScoped<IUnitOfWork, RegistrationUnitOfWork>();

		var registrationApplicationAssembly = typeof(UserRegisteredEventHandler).Assembly;
		services.AddMessageBroker<RegistrationDbContext>(configuration, RegistrationMicroservice.MicroserviceName, registrationApplicationAssembly);

		return services;
	}

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IConferenceRepository, ConferenceRepository>();

		return services;
	}
}
