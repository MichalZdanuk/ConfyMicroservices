
namespace ConferenceManagement.Infrastructure.Repositories;
public class PrelegentRepository(ConferenceManagementDbContext context)
	: IPrelegentRepository
{
	public async Task AddAsync(Prelegent prelegent)
	{
		await context.Prelegents.AddAsync(prelegent);
	}

	public async Task<bool> AllPrelegentsExistAsync(IList<Guid> prelegentIds)
	{
		var count = await context.Prelegents
			.Where(x => prelegentIds.Contains(x.Id))
			.CountAsync();

		return count == prelegentIds.Count;
	}

	public async Task<IReadOnlyList<Prelegent>> BrowseAsync(IList<Guid> prelegentIds)
	{
		var prelegents = await context.Prelegents
			.Where(x => prelegentIds.Contains(x.Id))
			.ToListAsync();

		return prelegents.AsReadOnly();
	}
}
