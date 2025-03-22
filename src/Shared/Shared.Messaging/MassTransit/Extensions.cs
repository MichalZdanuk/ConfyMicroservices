using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared.Messaging.MassTransit;
public static class Extensions
{
	public static IServiceCollection AddMessageBroker<TDbContext>(this IServiceCollection services,
		IConfiguration configuration, Assembly? assembly = null) where TDbContext : DbContext
	{
		services.AddMassTransit(config =>
		{
			config.SetKebabCaseEndpointNameFormatter();

			config.AddEntityFrameworkOutbox<TDbContext>(o =>
			{
				o.UseSqlServer();

				o.UseBusOutbox(); // configures MassTransit's Bus for automatic message dispatch after transaction commit
			});

			config.AddConfigureEndpointsCallback((context, name, cfg) =>
			{
				cfg.UseEntityFrameworkOutbox<TDbContext>(context);
			});

			if (assembly != null)
			{
				config.AddConsumers(assembly);
			}

			config.UsingRabbitMq((context, configurator) =>
			{
				configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
				{
					host.Username(configuration["MessageBroker:UserName"]!);
					host.Password(configuration["MessageBroker:Password"]!);
				});
				configurator.ConfigureEndpoints(context);
			});
		});

		return services;
	}
}
