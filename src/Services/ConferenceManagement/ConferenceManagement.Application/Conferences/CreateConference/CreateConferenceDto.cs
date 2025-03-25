namespace ConferenceManagement.Application.Conferences.CreateConference;
public record CreateConferenceDto(string Name,
	string Language,
	CreateConferenceLinksDto ConferenceLinksDto,
	CreateConferenceDetailsDto ConferenceDetailsDto,
	CreateAddressDto AddressDto);
