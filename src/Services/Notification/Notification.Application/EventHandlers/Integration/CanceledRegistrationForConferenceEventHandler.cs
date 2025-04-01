using MassTransit;
using Microsoft.Extensions.Logging;
using Notification.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Notification.Application.EventHandlers.Integration;
public class CanceledRegistrationForConferenceEventHandler
	: TransactionalConsumer<CanceledRegistrationForConferenceEvent>
{
	private readonly INotificationRepository _notificationRepository;
	private readonly ILogger<CanceledRegistrationForConferenceEventHandler> _logger;

	public CanceledRegistrationForConferenceEventHandler(INotificationRepository notificationRepository,
		ILogger<CanceledRegistrationForConferenceEventHandler> logger,
		IUnitOfWork unitOfWork) : base(unitOfWork, logger)
	{
		_notificationRepository = notificationRepository;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<CanceledRegistrationForConferenceEvent> context)
	{
		var notification = PrepareNotification(context.Message);

		await _notificationRepository.AddAsync(notification);
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
