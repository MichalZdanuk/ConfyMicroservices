using ConferenceManagement.Application.Conferences.BrowseConferences;
using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.GetConference;
public record GetConferenceDto(string Name,
	string ConferenceLanguage,
	ConferenceLinksDto ConferenceLinks,
	ConferenceDetailsDto ConferenceDetails,
	AddressDto Address,
	IReadOnlyList<LectureDto> Lectures);
