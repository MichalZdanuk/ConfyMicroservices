namespace ConferenceManagement.Domain.Repositories;
public interface IPrelegentRepository
{
	public Task AddAsync(Prelegent prelegent);
	public Task<bool> AllPrelegentsExistAsync(IList<Guid> prelegentIds);
	public Task<IReadOnlyList<Prelegent>> BrowseAsync(IList<Guid> prelegentIds);
}
