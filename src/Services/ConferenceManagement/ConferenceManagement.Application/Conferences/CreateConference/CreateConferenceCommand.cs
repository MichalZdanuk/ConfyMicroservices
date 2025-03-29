using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.CreateConference;
public record CreateConferenceCommand(string Name,
	ConferenceLanguage ConferenceLanguage,
	CreateConferenceLinksDto ConferenceLinks,
	CreateConferenceDetailsDto ConferenceDetails,
	CreateAddressDto Address) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
