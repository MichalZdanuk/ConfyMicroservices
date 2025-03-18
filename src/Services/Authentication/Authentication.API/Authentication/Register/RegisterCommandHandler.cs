using Authentication.API.Services;
using MassTransit;
using Shared.Messaging.Events;

namespace Authentication.API.Authentication.Register;

public class RegisterCommandHandler(ICustomAuthService customAuthService,
	IPublishEndpoint publishEndpoint)
	: IRequestHandler<RegisterCommand>
{
	public async Task Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		var user = await customAuthService.Register(command.Email, command.Password);

		var userRegisteredEvent = RetrieveUserRegisteredEvent(user);

		await publishEndpoint.Publish(userRegisteredEvent, cancellationToken);
	}

	private UserRegisteredEvent RetrieveUserRegisteredEvent(User user)
		=> new UserRegisteredEvent()
			{
				UserId = user.Id,
				Email = user.Email,
				UserRole = user.UserRole
			};
}
