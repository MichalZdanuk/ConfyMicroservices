using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Application.Factories;
using Notification.Application.Services;
using Notification.Domain.Enums;
using Notification.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Notification.Application.EventHandlers.Integration;
public class ConferenceUpdatedNotificationEventHandler
	: TransactionalConsumer<ConferenceUpdatedNotificationEvent>
{
	private readonly INotificationFactory _notificationFactory;
	private readonly INotificationSenderService _notificationSenderService;
	private readonly INotificationRepository _notificationRepository;
	private readonly IUserRepository _userRepository;
	private readonly ILogger<ConferenceUpdatedNotificationEventHandler> _logger;

	public ConferenceUpdatedNotificationEventHandler(INotificationFactory notificationFactory,
		INotificationSenderService notificationSenderService,
		INotificationRepository notificationRepository,
		IUserRepository userRepository,
		ILogger<ConferenceUpdatedNotificationEventHandler> logger,
		IUnitOfWork unitOfWork)
			: base(unitOfWork, logger)
	{
		_notificationFactory = notificationFactory;
		_notificationSenderService = notificationSenderService;
		_notificationRepository = notificationRepository;
		_userRepository = userRepository;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<ConferenceUpdatedNotificationEvent> context)
	{
		var userEmails = await _userRepository.GetUserEmailsByIdsAsync(context.Message.UserIds);

		var notifications = _notificationFactory.CreateNotifications(
			context.Message.UserIds,
			context.Message.ConferenceId,
			NotificationType.ConferenceUpdated,
			context.Message.ConferenceName);

		await _notificationRepository.AddRangeAsync(notifications);

		var notificationPayloads = notifications
			.Where(n => userEmails.ContainsKey(n.UserId))
			.Select(n => n.MapToPayload(userEmails[n.UserId]))
			.ToList();

		await _notificationSenderService.SendNotifications(notificationPayloads);
	}
}
