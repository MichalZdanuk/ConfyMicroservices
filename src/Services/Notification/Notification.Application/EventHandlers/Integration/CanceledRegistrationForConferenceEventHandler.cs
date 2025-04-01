using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Application.Services;
using Notification.Domain.Exceptions;
using Notification.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Notification.Application.EventHandlers.Integration;
public class CanceledRegistrationForConferenceEventHandler
	: TransactionalConsumer<CanceledRegistrationForConferenceEvent>
{
	private readonly IUserRepository _userRepository;
	private readonly INotificationRepository _notificationRepository;
	private readonly INotificationSenderService _notificationSenderService;
	private readonly ILogger<CanceledRegistrationForConferenceEventHandler> _logger;

	public CanceledRegistrationForConferenceEventHandler(IUserRepository userRepository,
		INotificationRepository notificationRepository,
		INotificationSenderService notificationSenderService,
		ILogger<CanceledRegistrationForConferenceEventHandler> logger,
		IUnitOfWork unitOfWork) : base(unitOfWork, logger)
	{
		_userRepository = userRepository;
		_notificationRepository = notificationRepository;
		_notificationSenderService = notificationSenderService;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<CanceledRegistrationForConferenceEvent> context)
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

	private Domain.Entities.Notification PrepareNotification(CanceledRegistrationForConferenceEvent canceledRegistrationForConferenceEvent)
	{
		var notification = Domain.Entities.Notification.Create(canceledRegistrationForConferenceEvent.UserId,
			canceledRegistrationForConferenceEvent.ConferenceId,
			Domain.Enums.NotificationType.RegistrationCanceled,
			$"Your registration for the conference \"{canceledRegistrationForConferenceEvent.ConferenceName}\" has been canceled. We hope to see you at a future event!");

		return notification;
	}
}
