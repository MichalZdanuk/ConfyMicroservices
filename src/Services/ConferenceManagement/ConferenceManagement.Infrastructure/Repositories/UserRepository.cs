namespace ConferenceManagement.Infrastructure.Repositories;
public class UserRepository(ConferenceManagementDbContext context)
	: IUserRepository
{
	public async Task AddAsync(User user)
	{
		await context.Users.AddAsync(user);
	}
}
