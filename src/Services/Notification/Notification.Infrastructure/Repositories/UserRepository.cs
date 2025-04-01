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
}
