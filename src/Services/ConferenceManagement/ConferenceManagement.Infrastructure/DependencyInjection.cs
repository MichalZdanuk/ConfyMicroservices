using ConferenceManagement.Application.EventHandlers.Integration;
using ConferenceManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interceptors;
using Shared.Messaging.MassTransit;
using Shared.UnitOfWork;

namespace ConferenceManagement.Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Database");

		services.AddRepositories();
		services.AddCustomInterceptors();

		services.AddDbContext<ConferenceManagementDbContext>((sp, options) =>
		{
			options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
			options.UseSqlServer(connectionString);
		});

		services.AddScoped<IUnitOfWork, ConferenceManagementUnitOfWork>();

		var conferenceManagementApplicationAssembly = typeof(UserRegisteredEventHandler).Assembly;
		services.AddMessageBroker<ConferenceManagementDbContext>(configuration, conferenceManagementApplicationAssembly);

		return services;
	}

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IConferenceRepository, ConferenceRepository>();
		services.AddScoped<ILectureRepository, LectureRepository>();
		services.AddScoped<IPrelegentRepository, PrelegentRepository>();

		return services;
	}
}
