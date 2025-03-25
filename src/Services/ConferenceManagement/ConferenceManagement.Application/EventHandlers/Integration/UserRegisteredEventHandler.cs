using Microsoft.Extensions.Logging;
using Shared.UnitOfWork;

namespace ConferenceManagement.Application.EventHandlers.Integration;
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

		await _userRepository.AddAsync(user);
	}

	private User PrepareUserFromEvent(UserRegisteredEvent userRegisteredEvent)
	{
		var user = User.Create(userRegisteredEvent.UserId,
			FullName.Of(userRegisteredEvent.FirstName, userRegisteredEvent.LastName),
			userRegisteredEvent.Email,
			userRegisteredEvent.UserRole);

		return user;
	}
}
