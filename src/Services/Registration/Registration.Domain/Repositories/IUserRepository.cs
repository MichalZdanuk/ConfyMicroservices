using Registration.Domain.Entities;

namespace Registration.Domain.Repositories;
public interface IUserRepository
{
	public Task AddUserAsync(User user);
}
