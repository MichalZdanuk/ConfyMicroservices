using ConferenceManagement.Application.Conferences.CreateConference;

namespace ConferenceManagement.Application.Conference.CreateConference;
public record CreateConferenceDto(string Name,
	string Language,
	CreateConferenceLinksDto ConferenceLinksDto,
	CreateConferenceDetailsDto ConferenceDetailsDto,
	CreateAddressDto AddressDto);
