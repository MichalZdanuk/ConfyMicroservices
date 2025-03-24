namespace ConferenceManagement.Domain.Repositories;
public interface IConferenceRepository
{
	Task<Conference?> GetByIdAsync(Guid id);
	Task<List<Conference>> BrowseAsync(int pageNumber, int pageSize);
	Task<int> CountAsync();
	Task AddAsync(Conference conference);
	Task UpdateAsync(Conference conference);
}
