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

	public async Task<Conference?> GetByIdAsync(Guid id)
	{
		return await context.Conferences.SingleOrDefaultAsync(c => c.Id == id);
	}
}
