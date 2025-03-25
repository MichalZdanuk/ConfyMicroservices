namespace ConferenceManagement.Application.Conferences.UpdateConfrerence;
public record UpdateConferenceDto(string Name,
	string Language,
	UpdateConferenceLinksDto conferenceLinksDto,
	UpdateConferenceDetailsDto conferenceDetailsDto,
	UpdateAddressDto AddressDto);
