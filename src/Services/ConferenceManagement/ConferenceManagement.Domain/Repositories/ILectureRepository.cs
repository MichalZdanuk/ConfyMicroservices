namespace ConferenceManagement.Domain.Repositories;
public interface ILectureRepository
{
	public Task AddAsync(Lecture lecture);
	public Task<Lecture?> GetAsync(Guid id);
	public Task<List<Lecture>> GetLecturesWithAssignmentsByConferenceIdAsync(Guid conferenceId);
	public Task UpdateAsync(Lecture lecture);
}
