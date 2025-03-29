using Registration.Application.Services;

namespace Registration.Application.Registrations.AddRegistration;
public class AddRegistrationCommandHandler(IRegistrationService registrationService)
	: IRequestHandler<AddRegistrationCommand, Guid>
{
	public async Task<Guid> Handle(AddRegistrationCommand command, CancellationToken cancellationToken)
	{
		var registrationId = await registrationService.RegisterUserForConferenceAsync(command.ConferenceId);

		return registrationId;
	}
}
