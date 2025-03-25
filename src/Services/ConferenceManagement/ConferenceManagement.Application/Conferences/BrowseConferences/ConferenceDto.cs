namespace ConferenceManagement.Application.Conferences.BrowseConferences;
public record ConferenceDto(Guid Id, string Name, string Language, ConferenceLinksDto ConferenceLinks, ConferenceDetailsDto ConferenceDetails, AddressDto Address);
