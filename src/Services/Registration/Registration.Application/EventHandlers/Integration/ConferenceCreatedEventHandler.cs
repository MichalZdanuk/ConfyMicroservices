using MassTransit;
using Microsoft.Extensions.Logging;
using Registration.Domain.Entities;
using Registration.Domain.Repositories;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace Registration.Application.EventHandlers.Integration;
public class ConferenceCreatedEventHandler
	: TransactionalConsumer<ConferenceCreatedEvent>
{
	private readonly IConferenceRepository _confrenceRepository;
	private readonly ILogger<ConferenceCreatedEventHandler> _logger;

	public ConferenceCreatedEventHandler(IConferenceRepository conferenceRepository,
		IUnitOfWork unitOfWork,
		ILogger<ConferenceCreatedEventHandler> logger)
		: base(unitOfWork, logger)
	{
		_confrenceRepository = conferenceRepository;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<ConferenceCreatedEvent> context)
	{
		var conference = PrepareConferenceFromEvent(context.Message);

		await _confrenceRepository.AddAsync(conference);
	}

	private Conference PrepareConferenceFromEvent(ConferenceCreatedEvent conferenceCreatedEvent)
	{
		var conference = Conference.Create(conferenceCreatedEvent.ConferenceId,
			conferenceCreatedEvent.StartDate,
			conferenceCreatedEvent.EndDate,
			conferenceCreatedEvent.Name);

		return conference;
	}
}
