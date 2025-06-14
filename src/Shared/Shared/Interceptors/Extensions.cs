﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Interceptors;
public static class Extensions
{
	public static IServiceCollection AddCustomInterceptors(this IServiceCollection services)
	{
		services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
		services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

		return services;
	}
}
