using ConferenceManagement.Application.Conferences.UpdateConfrerence;

namespace ConferenceManagement.Application.Conference.UpdateConfrerence;
public record UpdateConferenceDto(string Name,
	string Language,
	UpdateConferenceLinksDto conferenceLinksDto,
	UpdateConferenceDetailsDto conferenceDetailsDto,
	UpdateAddressDto AddressDto);
