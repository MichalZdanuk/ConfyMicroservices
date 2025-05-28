using ConferenceManagement.Infrastructure.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ConferenceManagement.Infrastructure;
public static class Extensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<ConferenceManagementDbContext>();

		context.Database.MigrateAsync().GetAwaiter().GetResult();

		await SeedAsync(context);
	}

	private static async Task SeedAsync(ConferenceManagementDbContext context)
	{
		await PrelegentSeeder.SeedPrelegentsAsync(context);
		await ConferenceSeeder.SeedConferenceAsync(context);
		await LectureSeeder.SeedLecturesAsync(context);
	}
}
