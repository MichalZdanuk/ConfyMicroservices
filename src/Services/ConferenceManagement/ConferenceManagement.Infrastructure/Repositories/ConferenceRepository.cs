using Shared.Enums;

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

	public async Task<List<Conference>> BrowseAsync(int pageNumber, int pageSize,
		List<ConferenceLanguage> languages, bool? isOnline = null,
		string? country = null, DateTime? startDate = null, DateTime? endDate = null)
	{
		var query = context.Conferences.AsQueryable();

		if (languages.Count > 0)
		{
			query = query.Where(r => languages.Contains(r.ConferenceLanguage));
		}

		if (isOnline.HasValue)
		{
			query = query.Where(c => c.ConferenceDetails.IsOnline == isOnline.Value);
		}

		if (!string.IsNullOrEmpty(country))
		{
			query = query.Where(c => c.Address.Country.ToLower() == country.ToLower());
		}

		if (startDate.HasValue)
		{
			query = query.Where(c => c.ConferenceDetails.StartDate >= startDate);
		}

		if (endDate.HasValue)
		{
			query = query.Where(c => c.ConferenceDetails.EndDate <= endDate);
		}

		return await query
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
