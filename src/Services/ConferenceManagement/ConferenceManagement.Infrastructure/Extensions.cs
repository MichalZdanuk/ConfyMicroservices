using ConferenceManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConferenceManagement.Infrastructure;
public static class Extensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<ConferenceManagementDbContext>();

		context.Database.MigrateAsync().GetAwaiter().GetResult();
	}
}
