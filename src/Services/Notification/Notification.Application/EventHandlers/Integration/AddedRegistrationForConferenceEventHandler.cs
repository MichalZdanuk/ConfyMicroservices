using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Application.Factories;
using Notification.Application.Services;
using Notification.Domain.Enums;
using Notification.Domain.Exceptions;
using Notification.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Notification.Application.EventHandlers.Integration;
public class AddedRegistrationForConferenceEventHandler
	: TransactionalConsumer<AddedRegistrationForConferenceEvent>
{
	private readonly INotificationFactory _notificationFactory;
	private readonly IUserRepository _userRepository;
	private readonly INotificationRepository _notificationRepository;
	private readonly INotificationSenderService _notificationSenderService;
	private readonly ILogger<AddedRegistrationForConferenceEventHandler> _logger;

	public AddedRegistrationForConferenceEventHandler(INotificationFactory notificationFactory,
		IUserRepository userRepository,
		INotificationRepository notificationRepository,
		INotificationSenderService notificationSenderService,
		ILogger<AddedRegistrationForConferenceEventHandler> logger,
		IUnitOfWork unitOfWork) : base(unitOfWork, logger)
	{
		_notificationFactory = notificationFactory;
		_userRepository = userRepository;
		_notificationRepository = notificationRepository;
		_notificationSenderService = notificationSenderService;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<AddedRegistrationForConferenceEvent> context)
	{
		var notification = _notificationFactory.CreateNotification(
			context.Message.UserId,
			context.Message.ConferenceId,
			NotificationType.Registration,
			context.Message.ConferenceName);

		var user = await _userRepository.GetByIdAsync(notification.UserId);

		if (user is null)
		{
			throw new UserNotFoundException(notification.UserId);
		}

		await _notificationRepository.AddAsync(notification);

		var notificationPayload = notification.MapToPayload(user.Email);

		await _notificationSenderService.SendNotificationAsync(notificationPayload);
	}
}
