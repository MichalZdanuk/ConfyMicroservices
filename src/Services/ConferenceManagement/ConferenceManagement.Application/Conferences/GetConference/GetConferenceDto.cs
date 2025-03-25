using ConferenceManagement.Application.Conference.BrowseConferences;
using ConferenceManagement.Application.Conferences.BrowseConferences;

namespace ConferenceManagement.Application.Conference.GetConference;
public record GetConferenceDto(string name,
	string language,
	ConferenceLinksDto ConferenceLinks,
	ConferenceDetailsDto ConferenceDetails,
	AddressDto Address,
	IReadOnlyList<LectureDto> Lectures);
