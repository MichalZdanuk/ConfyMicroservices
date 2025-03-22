namespace ConferenceManagement.Infrastructure.Repositories;
public class UserRepository(ConferenceManagementDbContext context)
	: IUserRepository
{
	public async Task AddUser(User user)
	{
		await context.Users.AddAsync(user);
	}
}
