using MassTransit;
using Microsoft.Extensions.Logging;
using Registration.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Registration.Application.EventHandlers.Integration;
public class ConferenceUpdatedEventHandler
	: TransactionalConsumer<ConferenceUpdatedEvent>
{
	private readonly IPublishEndpoint _publishEndpoint;
	private readonly IRegistrationRepository _registrationRepository;
	private readonly ILogger<ConferenceUpdatedEventHandler> _logger;

	public ConferenceUpdatedEventHandler(IRegistrationRepository registrationRepository,
		IUnitOfWork unitOfWork,
		ILogger<ConferenceUpdatedEventHandler> logger,
		IPublishEndpoint publishEndpoint)
		: base(unitOfWork, logger)
	{
		_publishEndpoint = publishEndpoint;
		_registrationRepository = registrationRepository;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<ConferenceUpdatedEvent> context)
	{
		var usersToNotify = await _registrationRepository.GetUserIdsByConferenceIdWithActiveRegistrationsAsync(context.Message.ConferenceId);

		if (usersToNotify.Any())
		{
			var conferenceUpdatedNotificationEvent = RetrieveConferenceUpdatedNotificationEvent(context.Message.ConferenceId,
				context.Message.ConferenceName,
				usersToNotify);

			await _publishEndpoint.Publish(conferenceUpdatedNotificationEvent);
		}
	}

	private ConferenceUpdatedNotificationEvent RetrieveConferenceUpdatedNotificationEvent(Guid ConferenceId,
		string ConferenceName,
		List<Guid> UserIds)
			=> new ConferenceUpdatedNotificationEvent()
			{
				ConferenceId = ConferenceId,
				ConferenceName = ConferenceName,
				UserIds = UserIds,
			};
}
