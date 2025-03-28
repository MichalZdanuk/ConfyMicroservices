namespace Registration.Application.Registrations.AddRegistration;
public record AddRegistrationCommand(Guid ConferenceId) : ICommand<Guid>;
