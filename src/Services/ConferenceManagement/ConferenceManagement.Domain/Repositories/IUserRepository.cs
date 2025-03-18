using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Repositories;
public interface IUserRepository
{
	public Task AddUser(User user);
}
