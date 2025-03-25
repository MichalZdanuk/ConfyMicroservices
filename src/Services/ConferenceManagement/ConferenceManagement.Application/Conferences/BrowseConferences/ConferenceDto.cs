using ConferenceManagement.Application.Conferences.BrowseConferences;

namespace ConferenceManagement.Application.Conference.BrowseConferences;
public record ConferenceDto(Guid Id, string Name, string Language, ConferenceLinksDto ConferenceLinks, ConferenceDetailsDto ConferenceDetails, AddressDto Address);
