using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Services;
using Shared.Context;
using Shared.DependencyInjection;
using System.Reflection;

namespace Notification.Application;

public static class Extensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services,
		IConfiguration configuration)
	{
		var notificationApplicationAssembly = Assembly.GetExecutingAssembly();

		services.AddMediatRWithBehaviors(notificationApplicationAssembly);

		services.AddConfyHttpContext();
		services.AddScoped<INotificationService, NotificationService>();

		return services;
	}
}
