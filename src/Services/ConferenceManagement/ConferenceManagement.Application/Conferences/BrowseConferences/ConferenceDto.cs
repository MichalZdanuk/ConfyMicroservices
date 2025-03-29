using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.BrowseConferences;
public record ConferenceDto(Guid Id, string Name, string ConferenceLanguage, ConferenceDetailsDto ConferenceDetails, AddressDto Address);
