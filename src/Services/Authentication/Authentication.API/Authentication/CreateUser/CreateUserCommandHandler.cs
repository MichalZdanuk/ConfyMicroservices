using Authentication.API.Services;
using MassTransit;
using Shared.Enums;
using Shared.Messaging.Events;

namespace Authentication.API.Authentication.Create;

public class CreateUserCommandHandler(ICustomAuthService customAuthService,
	IPublishEndpoint publishEndpoint)
	: IRequestHandler<CreateUserCommand>
{
	public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
	{
		var user = await customAuthService.Register(command.Id,
			command.FirstName,
			command.LastName,
			command.Email,
			command.Password,
			command.UserRole,
			command.Bio);

		await PublishIntegrationEvent(user, cancellationToken);
	}

	private async Task PublishIntegrationEvent(User user, CancellationToken cancellationToken)
	{
		if (user.UserRole == UserRole.Prelegent)
		{
			var userRegisteredEvent = RetrievePrelegentCreatedEvent(user);

			await publishEndpoint.Publish(userRegisteredEvent, cancellationToken);
		}
	}

	private PrelegentCreatedEvent RetrievePrelegentCreatedEvent(User user)
		=> new PrelegentCreatedEvent()
		{
			UserId = user.Id,
			Name = string.Concat(user.FullName.FirstName, " ", user.FullName.LastName),
			Email = user.Email,
			Bio = user.Bio ?? string.Empty,
		};
}
