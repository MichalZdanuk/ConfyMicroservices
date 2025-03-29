using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.UpdateConfrerence;
public record UpdateConferenceDto(string Name,
	ConferenceLanguage ConferenceLanguage,
	UpdateConferenceLinksDto conferenceLinksDto,
	UpdateConferenceDetailsDto conferenceDetailsDto,
	UpdateAddressDto AddressDto);
