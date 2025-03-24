namespace ConferenceManagement.Domain.Repositories;
public interface ILectureRepository
{
	public Task<List<Lecture>> GetLecturesByConferenceIdAsync(Guid conferenceId);
}
