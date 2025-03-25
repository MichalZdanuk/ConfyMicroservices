using Microsoft.Extensions.Logging;

namespace ConferenceManagement.Application.EventHandlers.Domain;
public class CreatedConferenceEventHandler(ILogger<CreatedConferenceEventHandler> logger,
	IPublishEndpoint publishEndpoint)
	: INotificationHandler<CreatedConferenceEvent>
{
	public async Task Handle(CreatedConferenceEvent domainEvent, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain event handled: {domainEvent}", domainEvent.GetType().Name);

		var conferenceCreatedEvent = RetrieveConferenceCreatedEvent(domainEvent);

		await publishEndpoint.Publish(conferenceCreatedEvent);
	}

	private ConferenceCreatedEvent RetrieveConferenceCreatedEvent(CreatedConferenceEvent domainEvent)
		=> new ConferenceCreatedEvent()
		{
			ConferenceId = domainEvent.ConferenceId,
			StartDate = domainEvent.StartDate,
			EndDate = domainEvent.EndDate,
			Name = domainEvent.Name,
		};
}
