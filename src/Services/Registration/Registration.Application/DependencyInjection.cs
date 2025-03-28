using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Registration.Application.Services;
using Shared.Context;
using Shared.DependencyInjection;
using System.Reflection;

namespace Registration.Application;
public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services,
		IConfiguration configuration)
	{
		var registrationApplicationAssembly = Assembly.GetExecutingAssembly();

		services.AddMediatRWithBehaviors(registrationApplicationAssembly);

		services.AddConfyHttpContext();

		services.AddScoped<IRegistrationService, RegistrationService>();

		return services;
	}
}
