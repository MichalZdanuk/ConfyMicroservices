using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.ValueObjects;

namespace ConferenceManagement.Domain.DomainService;
public interface IConferenceDomainService
{
	public Task<Conference> CreateConferenceAsync(Guid id, string name, ConferenceDetails details, Address address);
	public Task AddLectureToConferenceAsync(Guid conferenceId, Guid lectureId);
	public Task<List<Conference>> BrowseConferenceAsync(int pageNumber, int pageSize);
	public Task<int> CountAsync();
	public Task<(Conference? conference, List<Lecture>? lectures)> GetConferenceWithLectures(Guid conferenceId);
	public Task UpdateConferenceAsync(Guid conferenceId, string name, ConferenceDetails details, Address address);
}
