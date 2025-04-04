using Authentication.API.ValueObjects;
using Shared.Enums;

namespace Authentication.API.Seeding;

public static class AdminUserSeeder
{
	private const string _adminUserId = "BBFF5DEC-6B26-46BE-B8D3-DA434EBAB756";

	public static async Task SeedAdminUserAsync(AuthenticationDbContext context)
	{
		var adminUser = await context.Users
			.FirstOrDefaultAsync(u => u.Id == Guid.Parse(_adminUserId));

		if (adminUser is null)
		{
			var adminUserToCreate = User.Create(
				Guid.Parse(_adminUserId),
				"admin@confy.com",
				"$2a$11$NsE9iMBZWUmALmEw6WtRiuVhTkEBgaH/vbTXkOs46TuNlNZIhoCOy",
				FullName.Of("Admin", "User"),
				UserRole.Admin
			);

			await context.Users.AddAsync(adminUserToCreate);

			await context.SaveChangesAsync();
		}
	}
}
