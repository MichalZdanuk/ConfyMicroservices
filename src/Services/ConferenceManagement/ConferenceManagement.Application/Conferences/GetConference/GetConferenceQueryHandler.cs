using ConferenceManagement.Application.Conferences.BrowseConferences;

namespace ConferenceManagement.Application.Conferences.GetConference;
public class GetConferenceQueryHandler(IConferenceRepository conferenceRepository,
	ILectureRepository lectureRepository,
	IPrelegentRepository prelegentRepository)
	: IRequestHandler<GetConferenceQuery, GetConferenceDto>
{
	public async Task<GetConferenceDto> Handle(GetConferenceQuery query, CancellationToken cancellationToken)
	{
		var conference = await conferenceRepository.GetByIdAsync(query.ConferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(query.ConferenceId);
		}

		var lectures = await lectureRepository.GetLecturesWithAssignmentsByConferenceIdAsync(query.ConferenceId);
		var prelegentDictionary = await GetPrelegentDictionary(lectures);

		var lectureDtos = MapLecturesToDto(lectures, prelegentDictionary);

		return MapConferenceToDto(conference, lectureDtos);
	}

	private async Task<Dictionary<Guid, PrelegentDto>> GetPrelegentDictionary(List<Lecture> lectures)
	{
		var prelegentIds = lectures
			.SelectMany(l => l.LectureAssignments.Select(a => a.PrelegentId))
			.Distinct()
			.ToList();

		var prelegents = await prelegentRepository.BrowseAsync(prelegentIds);
		return prelegents.ToDictionary(p => p.Id, p => new PrelegentDto(p.Name, p.Bio));
	}

	private List<LectureDto> MapLecturesToDto(List<Lecture> lectures, Dictionary<Guid, PrelegentDto> prelegentDictionary)
	{
		return lectures.Select(l => new LectureDto(
			l.Id,
			new LectureDetailsDto(
				l.LectureDetails.Title,
				l.LectureDetails.StartDate,
				l.LectureDetails.EndDate
			),
			l.LectureAssignments.Select(a => prelegentDictionary[a.PrelegentId]).ToList()
		)).ToList();
	}

	private GetConferenceDto MapConferenceToDto(Conference conference, List<LectureDto> lectureDtos)
	{
		return new GetConferenceDto(
			conference.Name,
			conference.ConferenceLanguage.ToString(),
			new ConferenceLinksDto(
				conference.ConferenceLinks.WebsiteUrl,
				conference.ConferenceLinks.FacebookUrl,
				conference.ConferenceLinks.InstagramUrl
			),
			new ConferenceDetailsDto(
				conference.ConferenceDetails.StartDate,
				conference.ConferenceDetails.EndDate,
				conference.ConferenceDetails.Description,
				conference.ConferenceDetails.IsOnline
			),
			new AddressDto(
				conference.Address.City,
				conference.Address.Country,
				conference.Address.AddressLine,
				conference.Address.ZipCode
			),
			lectureDtos
		);
	}
}
