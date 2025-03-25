namespace ConferenceManagement.Domain.Repositories;
public interface ILectureRepository
{
	public Task AddAsync(Lecture lecture);
	public Task<List<Lecture>> GetLecturesByConferenceIdAsync(Guid conferenceId);
}
