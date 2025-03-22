namespace ConferenceManagement.Application.Conference.CreateConference;
public record CreateConferenceCommand(string Name, CreateConferenceDetailsDto ConferenceDetails, CreateAddressDto Address) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
