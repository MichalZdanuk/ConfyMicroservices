namespace ConferenceManagement.Application.Conferences.BrowseConferences;
public record ConferenceDto(Guid Id, string Name, string Language, ConferenceDetailsDto ConferenceDetails, AddressDto Address);
