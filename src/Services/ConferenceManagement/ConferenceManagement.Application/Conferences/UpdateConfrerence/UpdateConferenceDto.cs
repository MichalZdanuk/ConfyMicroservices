using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.UpdateConfrerence;
public record UpdateConferenceDto(ConferenceLanguage ConferenceLanguage,
	UpdateConferenceLinksDto conferenceLinksDto,
	UpdateConferenceDetailsDto conferenceDetailsDto,
	UpdateAddressDto AddressDto);
