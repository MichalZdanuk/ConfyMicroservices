using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Application.Services;
using Notification.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Notification.Application.EventHandlers.Integration;
public class AddedRegistrationForConferenceEventHandler
	: TransactionalConsumer<AddedRegistrationForConferenceEvent>
{
	private readonly INotificationRepository _notificationRepository;
	private readonly INotificationService _notificationService;
	private readonly ILogger<AddedRegistrationForConferenceEventHandler> _logger;

	public AddedRegistrationForConferenceEventHandler(INotificationRepository notificationRepository,
		INotificationService notificationService,
		ILogger<AddedRegistrationForConferenceEventHandler> logger,
		IUnitOfWork unitOfWork) : base(unitOfWork, logger)
	{
		_notificationRepository = notificationRepository;
		_notificationService = notificationService;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<AddedRegistrationForConferenceEvent> context)
	{
		var notification = PrepareNotification(context.Message);
		notification.MarkAsSent();

		await _notificationRepository.AddAsync(notification);

		await _notificationService.SendNotification(notification);
	}

	private Domain.Entities.Notification PrepareNotification(AddedRegistrationForConferenceEvent addedRegistrationForConferenceEvent)
	{
		var notification = Domain.Entities.Notification.Create(addedRegistrationForConferenceEvent.UserId,
			addedRegistrationForConferenceEvent.ConferenceId,
			Domain.Enums.NotificationType.Registration,
			$"You have successfully registered for the conference \"{addedRegistrationForConferenceEvent.ConferenceName}\". We look forward to seeing you there!");

		return notification;
	}
}
