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
public class CanceledRegistrationForConferenceEventHandler
	: TransactionalConsumer<CanceledRegistrationForConferenceEvent>
{
	private readonly INotificationFactory _notificationFactory;
	private readonly IUserRepository _userRepository;
	private readonly INotificationRepository _notificationRepository;
	private readonly INotificationSenderService _notificationSenderService;
	private readonly ILogger<CanceledRegistrationForConferenceEventHandler> _logger;

	public CanceledRegistrationForConferenceEventHandler(INotificationFactory notificationFactory,
		IUserRepository userRepository,
		INotificationRepository notificationRepository,
		INotificationSenderService notificationSenderService,
		ILogger<CanceledRegistrationForConferenceEventHandler> logger,
		IUnitOfWork unitOfWork) : base(unitOfWork, logger)
	{
		_notificationFactory = notificationFactory;
		_userRepository = userRepository;
		_notificationRepository = notificationRepository;
		_notificationSenderService = notificationSenderService;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<CanceledRegistrationForConferenceEvent> context)
	{
		var notification = _notificationFactory.CreateNotification(
			context.Message.UserId,
			context.Message.ConferenceId,
			NotificationType.RegistrationCanceled,
			context.Message.ConferenceName);

		var user = await _userRepository.GetByIdAsync(notification.UserId);

		if (user is null)
		{
			throw new UserNotFoundException(notification.UserId);
		}

		await _notificationRepository.AddAsync(notification);

		var notificationPayload = notification.MapToPayload(user.Email);

		await _notificationSenderService.SendNotification(notificationPayload);
	}
}
