namespace ConferenceManagement.Application.Conference.BrowseConferences;
public record ConferenceDto(Guid Id, string Name, ConferenceDetailsDto ConferenceDetails, AddressDto Address);
