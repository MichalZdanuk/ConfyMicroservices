using Registration.Domain.Entities;
using Registration.Domain.Repositories;

namespace Registration.Infrastucture.Repositories;
public class ConferenceRepository(RegistrationDbContext context)
	: IConferenceRepository
{
	public async Task AddAsync(Conference conference)
	{
		await context.AddAsync(conference);
	}
}
