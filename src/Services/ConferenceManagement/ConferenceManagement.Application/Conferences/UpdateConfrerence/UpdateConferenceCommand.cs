using ConferenceManagement.Application.Conferences.UpdateConfrerence;

namespace ConferenceManagement.Application.Conference.UpdateConfrerence;
public record UpdateConferenceCommand(Guid ConferenceId,
	string Name,
	string Language,
	UpdateConferenceLinksDto ConferenceLinks,
	UpdateConferenceDetailsDto ConferenceDetails,
	UpdateAddressDto Address) : ICommand;
