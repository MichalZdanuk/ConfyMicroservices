
namespace ConferenceManagement.Infrastructure.Repositories;
public class PrelegentRepository(ConferenceManagementDbContext context)
	: IPrelegentRepository
{
	public async Task AddPrelegentAsync(Prelegent prelegent)
	{
		await context.Prelegents.AddAsync(prelegent);
	}

	public async Task<bool> AllPrelegentsExist(IList<Guid> prelegentIds)
	{
		var count = await context.Prelegents
			.Where(x => prelegentIds.Contains(x.Id))
			.CountAsync();

		return count == prelegentIds.Count;
	}

	public async Task<IReadOnlyList<Prelegent>> BrowsePrelegentsAsync(IList<Guid> prelegentIds)
	{
		var prelegents = await context.Prelegents
			.Where(x => prelegentIds.Contains(x.Id))
			.ToListAsync();

		return prelegents.AsReadOnly();
	}
}
