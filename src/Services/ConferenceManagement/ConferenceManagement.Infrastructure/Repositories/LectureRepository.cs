namespace ConferenceManagement.Infrastructure.Repositories;
public class LectureRepository(ConferenceManagementDbContext context)
	: ILectureRepository
{
	public async Task AddAsync(Lecture lecture)
	{
		await context.AddAsync(lecture);
	}

	public async Task<Lecture?> GetByIdAsync(Guid id)
	{
		return await context.Lectures.SingleOrDefaultAsync(l => l.Id == id);
	}

	public Task<List<Lecture>> GetLecturesWithAssignmentsByConferenceIdAsync(Guid conferenceId)
	{
		return context.Lectures
			.Include(l => l.LectureAssignments)
			.Where(l => l.ConferenceId == conferenceId).ToListAsync();
	}

	public async Task UpdateAsync(Lecture lecture)
	{
		context.Lectures.Update(lecture);
	}
}
