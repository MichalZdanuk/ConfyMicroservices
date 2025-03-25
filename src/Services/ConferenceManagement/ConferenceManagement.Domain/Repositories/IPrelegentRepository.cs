namespace ConferenceManagement.Domain.Repositories;
public interface IPrelegentRepository
{
	public Task AddPrelegentAsync(Prelegent prelegent);
	public Task<bool> AllPrelegentsExist(IList<Guid> prelegentIds);
	public Task<IReadOnlyList<Prelegent>> BrowsePrelegentsAsync(IList<Guid> prelegentIds);
}
