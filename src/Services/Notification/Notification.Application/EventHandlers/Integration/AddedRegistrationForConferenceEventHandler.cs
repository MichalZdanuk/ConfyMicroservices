using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Application.Services;
using Notification.Domain.Exceptions;
using Notification.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Notification.Application.EventHandlers.Integration;
public class AddedRegistrationForConferenceEventHandler
	: TransactionalConsumer<AddedRegistrationForConferenceEvent>
{
	private readonly IUserRepository _userRepository;
	private readonly INotificationRepository _notificationRepository;
	private readonly INotificationSenderService _notificationSenderService;
	private readonly ILogger<AddedRegistrationForConferenceEventHandler> _logger;

	public AddedRegistrationForConferenceEventHandler(IUserRepository userRepository,
		INotificationRepository notificationRepository,
		INotificationSenderService notificationSenderService,
		ILogger<AddedRegistrationForConferenceEventHandler> logger,
		IUnitOfWork unitOfWork) : base(unitOfWork, logger)
	{
		_userRepository = userRepository;
		_notificationRepository = notificationRepository;
		_notificationSenderService = notificationSenderService;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<AddedRegistrationForConferenceEvent> context)
	{
		var notification = PrepareNotification(context.Message);
		notification.MarkAsSent();

		var user = await _userRepository.GetByIdAsync(notification.UserId);

		if (user is null)
		{
			throw new UserNotFoundException(notification.UserId);
		}

		await _notificationRepository.AddAsync(notification);

		var notificationPayload = PrepareNotificationPayload(notification, user.Email);

		await _notificationSenderService.SendNotification(notificationPayload);
	}

	private NotificationPayload PrepareNotificationPayload(Domain.Entities.Notification notification, string email)
		=> new NotificationPayload(notification.NotificationType.ToString(), email, notification.Content, notification.SentAt.HasValue ? DateTime.UtcNow : notification.SentAt!.Value);

	private Domain.Entities.Notification PrepareNotification(AddedRegistrationForConferenceEvent addedRegistrationForConferenceEvent)
	{
		var notification = Domain.Entities.Notification.Create(addedRegistrationForConferenceEvent.UserId,
			addedRegistrationForConferenceEvent.ConferenceId,
			Domain.Enums.NotificationType.Registration,
			$"You have successfully registered for the conference \"{addedRegistrationForConferenceEvent.ConferenceName}\". We look forward to seeing you there!");

		return notification;
	}
}
