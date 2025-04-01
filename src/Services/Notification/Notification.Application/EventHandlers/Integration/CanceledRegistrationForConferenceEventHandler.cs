using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Application.Services;
using Notification.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Notification.Application.EventHandlers.Integration;
public class CanceledRegistrationForConferenceEventHandler
	: TransactionalConsumer<CanceledRegistrationForConferenceEvent>
{
	private readonly INotificationRepository _notificationRepository;
	private readonly INotificationService _notificationService;
	private readonly ILogger<CanceledRegistrationForConferenceEventHandler> _logger;

	public CanceledRegistrationForConferenceEventHandler(INotificationRepository notificationRepository,
		INotificationService notificationService,
		ILogger<CanceledRegistrationForConferenceEventHandler> logger,
		IUnitOfWork unitOfWork) : base(unitOfWork, logger)
	{
		_notificationRepository = notificationRepository;
		_notificationService = notificationService;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<CanceledRegistrationForConferenceEvent> context)
	{
		var notification = PrepareNotification(context.Message);
		notification.MarkAsSent();

		await _notificationRepository.AddAsync(notification);

		await _notificationService.SendNotification(notification);
	}

	private Domain.Entities.Notification PrepareNotification(CanceledRegistrationForConferenceEvent canceledRegistrationForConferenceEvent)
	{
		var notification = Domain.Entities.Notification.Create(canceledRegistrationForConferenceEvent.UserId,
			canceledRegistrationForConferenceEvent.ConferenceId,
			Domain.Enums.NotificationType.RegistrationCanceled,
			$"Your registration for the conference \"{canceledRegistrationForConferenceEvent.ConferenceName}\" has been canceled. We hope to see you at a future event!");

		return notification;
	}
}
