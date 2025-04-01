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
	private readonly IRegistrationRepository _registrationRepository;
	private readonly ILogger<ConferenceUpdatedEventHandler> _logger;

	public ConferenceUpdatedEventHandler(IRegistrationRepository registrationRepository,
		IUnitOfWork unitOfWork,
		ILogger<ConferenceUpdatedEventHandler> logger)
		: base(unitOfWork, logger)
	{
		_registrationRepository = registrationRepository;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<ConferenceUpdatedEvent> context)
	{
		var usersToNotify = await _registrationRepository.GetUserIdsByConferenceIdWithActiveRegistrationsAsync(context.Message.ConferenceId);

		if (usersToNotify.Any())
		{
			// TO DO: send integration event to Notification Microservice (with userIds and conferenceId and conferenceName)
		}

	}
}
