namespace ConferenceManagement.Domain.Repositories;
public interface IConferenceRepository
{
	Task<Conference?> GetByIdAsync(Guid id);
	Task<List<Conference>> BrowseAsync(int pageNumber, int pageSize, List<ConferenceLanguage> languages,
		bool? isOnline = null, string? country = null, DateTime? startDate = null, DateTime? endDate = null);
	Task<int> CountAsync();
	Task AddAsync(Conference conference);
	Task UpdateAsync(Conference conference);
}
