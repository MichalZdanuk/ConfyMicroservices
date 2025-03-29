using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.UpdateConfrerence;
public record UpdateConferenceCommand(Guid ConferenceId,
	string Name,
	ConferenceLanguage ConferenceLanguage,
	UpdateConferenceLinksDto ConferenceLinks,
	UpdateConferenceDetailsDto ConferenceDetails,
	UpdateAddressDto Address) : ICommand;
