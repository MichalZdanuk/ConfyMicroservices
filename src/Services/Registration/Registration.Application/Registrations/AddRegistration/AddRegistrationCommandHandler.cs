using Registration.Application.Services;
using Shared.Context;

namespace Registration.Application.Registrations.AddRegistration;
public class AddRegistrationCommandHandler(IContext context,
	IRegistrationService registrationService)
	: IRequestHandler<AddRegistrationCommand, Guid>
{
	public async Task<Guid> Handle(AddRegistrationCommand command, CancellationToken cancellationToken)
	{
		var registrationId = await registrationService.RegisterUserForConferenceAsync(context.UserId, command.ConferenceId);

		return registrationId;
	}
}
