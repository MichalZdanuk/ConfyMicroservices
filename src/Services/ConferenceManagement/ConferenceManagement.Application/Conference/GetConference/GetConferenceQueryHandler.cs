using ConferenceManagement.Application.Conference.BrowseConferences;
using ConferenceManagement.Domain.DomainService;
using ConferenceManagement.Domain.Exceptions;
using MediatR;

namespace ConferenceManagement.Application.Conference.GetConference;
public class GetConferenceQueryHandler(IConferenceDomainService conferenceDomainService)
	: IRequestHandler<GetConferenceQuery, GetConferenceDto>
{
	public async Task<GetConferenceDto> Handle(GetConferenceQuery query, CancellationToken cancellationToken)
	{
		var (conference, lectures) = await conferenceDomainService.GetConferenceWithLectures(query.ConferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(query.ConferenceId);
		}

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
