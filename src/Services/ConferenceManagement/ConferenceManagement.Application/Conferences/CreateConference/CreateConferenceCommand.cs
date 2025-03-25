using ConferenceManagement.Application.Conferences.CreateConference;

namespace ConferenceManagement.Application.Conference.CreateConference;
public record CreateConferenceCommand(string Name,
	string Language,
	CreateConferenceLinksDto ConferenceLinks,
	CreateConferenceDetailsDto ConferenceDetails,
	CreateAddressDto Address) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
