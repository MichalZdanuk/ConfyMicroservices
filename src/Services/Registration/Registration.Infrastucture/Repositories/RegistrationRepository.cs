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

	public async Task<Domain.Entities.Registration?> GetByIdAsync(Guid id)
	{
		return await context.Registrations
			.Include(r => r.Conference)
			.SingleOrDefaultAsync(r => r.Id == id);
	}

	public async Task<IList<Domain.Entities.Registration>> BrowseByUserIdAsync(Guid userId)
	{
		return await context.Registrations
			.Include(r => r.Conference)
			.Where(r => r.UserId == userId)
			.OrderBy(r => r.Conference.StartDate)
			.ToListAsync();
	}

	public async Task<int> CountByUserIdAsync(Guid userId)
	{
		return await context.Registrations.CountAsync(r => r.UserId == userId);
	}
}
