using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Context;
using Shared.DependencyInjection;
using System.Reflection;

namespace ConferenceManagement.Application;
public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services,
		IConfiguration configuration)
	{
		var conferenceManagementApplicationAssembly = Assembly.GetExecutingAssembly();

		services.AddMediatRWithBehaviors(conferenceManagementApplicationAssembly);

		services.AddConfyHttpContext();

		return services;
	}
}
