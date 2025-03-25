namespace Registration.Domain.Repositories;
public interface IConferenceRepository
{
	public Task AddAsync(Conference conference);
}
