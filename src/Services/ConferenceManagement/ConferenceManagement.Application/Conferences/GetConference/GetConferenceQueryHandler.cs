using ConferenceManagement.Application.Conference.BrowseConferences;

namespace ConferenceManagement.Application.Conference.GetConference;
public class GetConferenceQueryHandler(IConferenceRepository conferenceRepository,
	ILectureRepository lectureRepository)
	: IRequestHandler<GetConferenceQuery, GetConferenceDto>
{
	public async Task<GetConferenceDto> Handle(GetConferenceQuery query, CancellationToken cancellationToken)
	{
		var conference = await conferenceRepository.GetByIdAsync(query.ConferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(query.ConferenceId);
		}

		var lectures = await lectureRepository.GetLecturesByConferenceIdAsync(query.ConferenceId);

		var conferenceDto = new GetConferenceDto(
			conference.Name,
			new ConferenceDetailsDto(
				conference.ConferenceDetails.StartDate,
				conference.ConferenceDetails.EndDate,
				conference.ConferenceDetails.Description
			),
			new AddressDto(
				conference.Address.City,
				conference.Address.Country,
				conference.Address.AddressLine,
				conference.Address.ZipCode
			),
			lectures.Select(l => new LectureDetailsDto(
				l.Id,
				l.LectureDetails.Title,
				l.LectureDetails.StartDate,
				l.LectureDetails.EndDate
			)).ToList()
		);

		return conferenceDto;
	}
}
