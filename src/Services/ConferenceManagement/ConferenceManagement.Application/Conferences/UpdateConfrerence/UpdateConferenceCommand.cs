namespace ConferenceManagement.Application.Conferences.UpdateConfrerence;
public record UpdateConferenceCommand(Guid ConferenceId,
	string Name,
	string Language,
	UpdateConferenceLinksDto ConferenceLinks,
	UpdateConferenceDetailsDto ConferenceDetails,
	UpdateAddressDto Address) : ICommand;
