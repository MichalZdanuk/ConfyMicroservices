using Shared.Seeding;

namespace ConferenceManagement.Infrastructure.Seeding;
public static class PrelegentSeeder
{
	public static async Task SeedPrelegentsAsync(ConferenceManagementDbContext context)
	{
		if (context.Prelegents.Any()) return;

		var prelegents = new List<Prelegent>();
		var ids = SeedConstants.PrelegentIds;

		for (int i = 0; i < ids.Length; i++)
		{
			var id = ids[i];
			string name = $"Speaker {i + 1}";
			string bio = $"Experienced .NET Professional #{i + 1}";

			prelegents.Add(Prelegent.Create(id, name, bio));
		}

		await context.Prelegents.AddRangeAsync(prelegents);
		await context.SaveChangesAsync();
	}
}
