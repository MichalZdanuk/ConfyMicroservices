namespace Notification.Infrastructure.Repositories;
public class UserRepository(NotificationDbContext dbContext)
	: IUserRepository
{
	public async Task AddUserAsync(User user)
	{
		await dbContext.Users.AddAsync(user);
	}
}
