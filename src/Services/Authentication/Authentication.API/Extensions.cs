using Authentication.API.Seeding;

namespace Authentication.API;

public static class Extensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<AuthenticationDbContext>();

		context.Database.MigrateAsync().GetAwaiter().GetResult();

		await SeedAsync(context);
	}

	private static async Task SeedAsync(AuthenticationDbContext context)
	{
		await AdminUserSeeder.SeedAdminUserAsync(context);
	}
}
