using MassTransit;
using Microsoft.Extensions.Logging;
using Registration.Domain.Entities;
using Registration.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Registration.Application.EventHandlers.Integration;
public class UserRegisteredEventHandler
	: TransactionalConsumer<UserRegisteredEvent>
{
	private readonly IUserRepository _userRepository;
	private readonly ILogger<UserRegisteredEventHandler> _logger;

	public UserRegisteredEventHandler(IUserRepository userRepository,
		IUnitOfWork unitOfWork,
		ILogger<UserRegisteredEventHandler> logger)
		: base(unitOfWork, logger)
	{
		_userRepository = userRepository;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<UserRegisteredEvent> context)
	{
		var user = PrepareUserFromEvent(context.Message);

		await _userRepository.AddUserAsync(user);
	}

	private User PrepareUserFromEvent(UserRegisteredEvent userRegisteredEvent)
	{
		var user = User.Create(userRegisteredEvent.UserId,
			userRegisteredEvent.Email);

		return user;
	}
}
