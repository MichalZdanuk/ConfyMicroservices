using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Repositories;
public interface IUserRepository
{
	public Task AddUserAsync(User user);
}
