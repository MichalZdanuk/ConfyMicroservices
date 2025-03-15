using Authentication.API.DAL;

namespace Authentication.API;

public static class Extensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<AuthenticationDbContext>();

		context.Database.MigrateAsync().GetAwaiter().GetResult();
	}
}
