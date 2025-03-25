using ConferenceManagement.Application.Conference.BrowseConferences;

namespace ConferenceManagement.Application.Conference.GetConference;
public record GetConferenceDto(string name, ConferenceDetailsDto ConferenceDetails, AddressDto Address, IReadOnlyList<LectureDto> Lectures);
