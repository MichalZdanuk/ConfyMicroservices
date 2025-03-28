namespace Registration.Application.Registrations.CancelRegistration;
public record CancelRegistrationCommand(Guid RegistrationId) : ICommand;
