using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.CreateConference;
public record CreateConferenceDto(string Name,
	ConferenceLanguage ConferenceLanguage,
	CreateConferenceLinksDto ConferenceLinksDto,
	CreateConferenceDetailsDto ConferenceDetailsDto,
	CreateAddressDto AddressDto);
