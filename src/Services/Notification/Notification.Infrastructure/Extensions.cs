using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notification.Infrastructure.Data;

namespace Notification.Infrastructure;
public static class Extensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<NotificationDbContext>();

		context.Database.MigrateAsync().GetAwaiter().GetResult();
	}
}
