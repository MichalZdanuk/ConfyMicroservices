using Registration.Domain.Repositories;

namespace Registration.Infrastucture.Repositories;
public class RegistrationRepository(RegistrationDbContext context)
	: IRegistrationRepository
{
	public async Task AddAsync(Domain.Entities.Registration registration)
	{
		await context.Registrations.AddAsync(registration);
	}

	public async Task UpdateAsync(Domain.Entities.Registration registration)
	{
		context.Registrations.Update(registration);
	}

	public async Task<Domain.Entities.Registration?> GetByUserIdAndConferenceId(Guid userId, Guid conferenceId)
	{
		return await context.Registrations
			.Include(r => r.Conference)
			.SingleOrDefaultAsync(r => r.UserId == userId && r.ConferenceId == conferenceId);
	}
}
