using Registration.Domain.Entities;
using Registration.Domain.Repositories;

namespace Registration.Infrastucture.Repositories;
public class UserRepository(RegistrationDbContext dbContext)
	: IUserRepository
{
	public async Task AddUserAsync(User user)
	{
		await dbContext.Users.AddAsync(user);
	}
}
