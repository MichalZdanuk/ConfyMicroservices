namespace Registration.Domain.Repositories;
public interface IRegistrationRepository
{
	public Task AddAsync(Entities.Registration registration);
	public Task UpdateAsync(Entities.Registration registration);
	public Task<Entities.Registration?> GetByIdAsync(Guid id);
	public Task<Entities.Registration?> GetByUserIdAndConferenceId(Guid userId, Guid conferenceId);
	public Task<IList<Entities.Registration>> BrowseByUserIdAsync(Guid userId, bool onlyPending, int pageNumber, int pageSize);
	public Task<IList<Entities.Registration>> BrowseByConferenceIdAsync(Guid conferenceId, List<RegistrationStatus> statuses);
	public Task<int> CountByUserIdAsync(Guid userId);
	public Task<List<Guid>> GetUserIdsByConferenceIdWithActiveRegistrationsAsync(Guid conferenceId);
}
