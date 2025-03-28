using Registration.Application.Services;
using Shared.Context;

namespace Registration.Application.Registrations.AddRegistration;
public class AddRegistrationCommandHandler(IContext context,
	IRegistrationService registrationService)
	: IRequestHandler<AddRegistrationCommand>
{
	public async Task Handle(AddRegistrationCommand command, CancellationToken cancellationToken)
	{
		await registrationService.RegisterUserForConferenceAsync(context.UserId, command.ConferenceId);
	}
}
