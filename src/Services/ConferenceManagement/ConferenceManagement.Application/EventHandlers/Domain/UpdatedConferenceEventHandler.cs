using Microsoft.Extensions.Logging;

namespace ConferenceManagement.Application.EventHandlers.Domain;
public class UpdatedConferenceEventHandler(ILogger<UpdatedConferenceEventHandler> logger,
	IPublishEndpoint publishEndpoint)
	: INotificationHandler<UpdatedConferenceEvent>
{
	public async Task Handle(UpdatedConferenceEvent domainEvent, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain event handled: {domainEvent}", domainEvent.GetType().Name);

		var conferenceUpdatedEvent = RetrieveConferenceUpdatedEvent(domainEvent);

		await publishEndpoint.Publish(conferenceUpdatedEvent);
	}

	private ConferenceUpdatedEvent RetrieveConferenceUpdatedEvent(UpdatedConferenceEvent domainEvent)
		=> new ConferenceUpdatedEvent()
		{
			ConferenceId = domainEvent.ConferenceId,
			ConferenceName = domainEvent.ConferenceName,
		};
}
