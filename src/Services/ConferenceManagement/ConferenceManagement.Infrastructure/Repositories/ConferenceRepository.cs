namespace ConferenceManagement.Infrastructure.Repositories;
public class ConferenceRepository(ConferenceManagementDbContext context)
	: IConferenceRepository
{
	public async Task<Conference?> GetByIdAsync(Guid id)
	{
		var conference = await context.Conferences
			.FirstOrDefaultAsync(c => c.Id == id);

		if (conference is null)
		{
			return null;
		}

		var lectureIds = await context.Lectures
			.Where(l => l.ConferenceId == id)
			.Select(l => l.Id)
			.ToListAsync();

		foreach (var lectureId in lectureIds)
		{
			conference.AddLecture(lectureId);
		}

		return conference;
	}

	public async Task<List<Conference>> BrowseAsync(int pageNumber, int pageSize)
	{
		return await context.Conferences
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
	}

	public async Task<int> CountAsync()
	{
		return await context.Conferences.CountAsync();
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
