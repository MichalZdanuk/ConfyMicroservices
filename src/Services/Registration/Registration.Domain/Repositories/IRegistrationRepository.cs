namespace Registration.Domain.Repositories;
public interface IRegistrationRepository
{
	public Task AddAsync(Entities.Registration registration);
	public Task UpdateAsync(Entities.Registration registration);
	public Task<Entities.Registration?> GetByUserIdAndConferenceId(Guid userId, Guid conferenceId);
}
