using ConferenceManagement.Domain.Data;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Exceptions;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.ValueObjects;

namespace ConferenceManagement.Domain.DomainService;
public class ConferenceDomainService(IConferenceRepository conferenceRepository,
	IDbContext dbContext)
	: IConferenceDomainService
{
	public async Task<Conference> CreateConferenceAsync(Guid id, string name, ConferenceDetails details, Address address)
	{
		var conference = Conference.Create(id, name, details, address);
		await conferenceRepository.AddAsync(conference);

		await dbContext.SaveChangesAsync();
		return conference;
	}

	public async Task AddLectureToConferenceAsync(Guid conferenceId, Guid lectureId)
	{
		var conference = await conferenceRepository.GetByIdAsync(conferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(conferenceId);
		}

		conference.AddLecture(lectureId);
		await conferenceRepository.UpdateAsync(conference);

		await dbContext.SaveChangesAsync();
	}

	public async Task<List<Conference>> BrowseConferenceAsync()
	{
		return await conferenceRepository.GetAllAsync();
	}

	public async Task UpdateConferenceAsync(Guid conferenceId, string name, ConferenceDetails details, Address address)
	{
		var conference = await conferenceRepository.GetByIdAsync(conferenceId);
		if (conference is null)
		{
			throw new ConferenceNotFoundException(conferenceId);
		}

		conference.Update(name, details, address);

		await dbContext.SaveChangesAsync();
	}
}
