using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.UpdateConfrerence;
public record UpdateConferenceCommand(Guid ConferenceId,
	ConferenceLanguage ConferenceLanguage,
	UpdateConferenceLinksDto ConferenceLinks,
	UpdateConferenceDetailsDto ConferenceDetails,
	UpdateAddressDto Address) : ICommand;
