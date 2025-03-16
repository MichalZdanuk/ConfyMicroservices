using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Context;
public static class Extensions
{
	public static IServiceCollection AddConfyHttpContext(this IServiceCollection services)
	{
		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		services.AddScoped<IContext, ConfyHttpContext>();

		return services;
	}
}
