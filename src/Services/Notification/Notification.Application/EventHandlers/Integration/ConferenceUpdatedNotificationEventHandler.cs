using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Application.Services;
using Notification.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Notification.Application.EventHandlers.Integration;
public class ConferenceUpdatedNotificationEventHandler
	: TransactionalConsumer<ConferenceUpdatedNotificationEvent>
{
	private readonly INotificationSenderService _notificationSenderService;
	private readonly INotificationRepository _notificationRepository;
	private readonly IUserRepository _userRepository;
	private readonly ILogger<ConferenceUpdatedNotificationEventHandler> _logger;

	public ConferenceUpdatedNotificationEventHandler(INotificationSenderService notificationSenderService,
		INotificationRepository notificationRepository,
		IUserRepository userRepository,
		ILogger<ConferenceUpdatedNotificationEventHandler> logger,
		IUnitOfWork unitOfWork)
			: base(unitOfWork, logger)
	{
		_notificationSenderService = notificationSenderService;
		_notificationRepository = notificationRepository;
		_userRepository = userRepository;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<ConferenceUpdatedNotificationEvent> context)
	{
		var userEmails = await _userRepository.GetUserEmailsByIdsAsync(context.Message.UserIds);

		var notifications = PrepareNotifications(context.Message);

		await _notificationRepository.AddRangeAsync(notifications);

		var notificationPayloads = notifications
			.Where(n => userEmails.ContainsKey(n.UserId))
			.Select(n => PrepareNotificationPayload(n, userEmails[n.UserId]))
			.ToList();

		await _notificationSenderService.SendNotifications(notificationPayloads);
	}

	private List<Domain.Entities.Notification> PrepareNotifications(ConferenceUpdatedNotificationEvent conferenceUpdatedNotificationEvent)
	{
		var notifications = new List<Domain.Entities.Notification>();

		foreach(var userId in conferenceUpdatedNotificationEvent.UserIds)
		{
			notifications.Add(Domain.Entities.Notification.Create(userId,
				conferenceUpdatedNotificationEvent.ConferenceId,
				Domain.Enums.NotificationType.ConferenceUpdated,
				$"There’s an important update regarding conference: \"{conferenceUpdatedNotificationEvent.ConferenceName}\". Please check the latest details."));
		}

		return notifications;
	}

	private NotificationPayload PrepareNotificationPayload(Domain.Entities.Notification notification, string email)
		=> new NotificationPayload(notification.NotificationType.ToString(), email, notification.Content, notification.SentAt ?? DateTime.UtcNow);
}
