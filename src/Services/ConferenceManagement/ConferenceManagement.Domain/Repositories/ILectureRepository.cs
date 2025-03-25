namespace ConferenceManagement.Domain.Repositories;
public interface ILectureRepository
{
	public Task AddAsync(Lecture lecture);
	public Task<Lecture?> GetByIdAsync(Guid id);
	public Task<Lecture?> GetWithAssignmentsByIdAsync(Guid id);
	public Task<List<Lecture>> GetLecturesWithAssignmentsByConferenceIdAsync(Guid conferenceId);
	public Task UpdateAsync(Lecture lecture);
}
