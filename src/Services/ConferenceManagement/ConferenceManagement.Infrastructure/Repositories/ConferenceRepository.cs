using ConferenceManagement.Domain.Data;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManagement.Infrastructure.Repositories;
public class ConferenceRepository(IDbContext context)
	: IConferenceRepository
{
	public async Task<Conference?> GetByIdAsync(Guid id)
	{
		return await context.Conferences
			.Include(c => c.LectureIds)
			.FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<List<Conference>> GetAllAsync()
	{
		return await context.Conferences.ToListAsync();
	}

	public async Task AddAsync(Conference conference)
	{
		await context.Conferences.AddAsync(conference);
	}

	public async Task UpdateAsync(Conference conference)
	{
		context.Conferences.Update(conference);
	}
}
