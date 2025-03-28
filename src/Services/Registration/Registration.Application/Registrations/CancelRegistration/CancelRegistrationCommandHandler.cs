using Registration.Application.Services;

namespace Registration.Application.Registrations.CancelRegistration;
public class CancelRegistrationCommandHandler(IRegistrationService registrationService)
	: IRequestHandler<CancelRegistrationCommand>
{
	public async Task Handle(CancelRegistrationCommand command, CancellationToken cancellationToken)
	{
		await registrationService.CancelRegistrationAsync(command.RegistrationId);
	}
}
