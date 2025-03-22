using ConferenceManagement.Domain.Entities;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Consumers;
using Shared.Messaging.Events;
using Shared.UnitOfWork;

namespace ConferenceManagement.Application.EventHandlers.Integration;
public class PrelegentCreatedEventHandler
	: TransactionalConsumer<PrelegentCreatedEvent>
{
	private readonly IPrelegentRepository _prelegentRepository;
	private readonly ILogger<PrelegentCreatedEventHandler> _logger;


	public PrelegentCreatedEventHandler(IPrelegentRepository prelegentRepository,
		IUnitOfWork unitOfWork,
		ILogger<PrelegentCreatedEventHandler> logger)
			: base(unitOfWork, logger)
	{
		_prelegentRepository = prelegentRepository;
		_logger = logger;
	}

	protected override async Task HandleMessage(ConsumeContext<PrelegentCreatedEvent> context)
	{
		var prelegent = PreparePrelegentFromEvent(context.Message);

		await _prelegentRepository.AddPrelegentAsync(prelegent);
	}

	private Prelegent PreparePrelegentFromEvent(PrelegentCreatedEvent prelegentCreatedEvent)
	{
		var user = Prelegent.Create(prelegentCreatedEvent.UserId,
			prelegentCreatedEvent.Name,
			prelegentCreatedEvent.Bio);

		return user;
	}
}
