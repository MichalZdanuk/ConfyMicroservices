namespace ConferenceManagement.Application.Conference.UpdateConfrerence;
public record UpdateConferenceCommand(Guid ConferenceId, string Name, UpdateConferenceDetailsDto ConferenceDetails, UpdateAddressDto Address) : ICommand;
