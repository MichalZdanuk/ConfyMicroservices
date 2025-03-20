using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Repositories;
public interface IConferenceRepository
{
	Task<Conference?> GetByIdAsync(Guid id);
	Task<List<Conference>> GetAllAsync();
	Task AddAsync(Conference conference);
	Task UpdateAsync(Conference conference);
}
