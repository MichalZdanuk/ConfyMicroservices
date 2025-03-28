namespace Registration.Application.Registrations.AddRegistration;
public record AddRegistrationCommand(Guid ConferenceId) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
