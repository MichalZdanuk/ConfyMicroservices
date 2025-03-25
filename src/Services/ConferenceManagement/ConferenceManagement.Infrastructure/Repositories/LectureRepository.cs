namespace ConferenceManagement.Infrastructure.Repositories;
public class LectureRepository(ConferenceManagementDbContext context)
	: ILectureRepository
{
	public async Task AddAsync(Lecture lecture)
	{
		await context.AddAsync(lecture);
	}

	public Task<List<Lecture>> GetLecturesByConferenceIdAsync(Guid conferenceId)
	{
		return context.Lectures.Where(l => l.ConferenceId == conferenceId).ToListAsync();
	}
}
