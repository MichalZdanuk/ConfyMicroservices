namespace Notification.Domain.Repositories;
public interface IUserRepository
{
	public Task AddAsync(User user);
	public Task<User?> GetByIdAsync(Guid id);
	public Task<Dictionary<Guid, string>> GetUserEmailsByIdsAsync(IEnumerable<Guid> userIds);
}
