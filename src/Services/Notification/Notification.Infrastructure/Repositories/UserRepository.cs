namespace Notification.Infrastructure.Repositories;
public class UserRepository(NotificationDbContext dbContext)
	: IUserRepository
{
	public async Task AddAsync(User user)
	{
		await dbContext.Users.AddAsync(user);
	}

	public async Task<User?> GetByIdAsync(Guid id)
	{
		return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
	}

	public async Task<Dictionary<Guid, string>> GetUserEmailsByIdsAsync(IEnumerable<Guid> userIds)
	{
		return await dbContext.Users
			.Where(u => userIds.Contains(u.Id))
			.ToDictionaryAsync(u => u.Id, u => u.Email);
	}
}
