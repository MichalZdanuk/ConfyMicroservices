using MassTransit;
using Microsoft.Extensions.Logging;
using Registration.Domain.Events;
using Shared.Messaging.Events;

namespace Registration.Application.EventHandlers.Domain;
public class UserReRegisteredForConferenceEventHandler(ILogger<UserReRegisteredForConferenceEventHandler> logger,
	IPublishEndpoint publishEndpoint)
	: INotificationHandler<UserReRegisteredForConferenceEvent>
{
	public async Task Handle(UserReRegisteredForConferenceEvent domainEvent, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain event handled: {domainEvent}", domainEvent.GetType().Name);

		var addedRegistrationForConferenceEvent = RetrieveAddedRegistrationForConferenceEvent(domainEvent);

		await publishEndpoint.Publish(addedRegistrationForConferenceEvent, cancellationToken);
	}

	private AddedRegistrationForConferenceEvent RetrieveAddedRegistrationForConferenceEvent(UserReRegisteredForConferenceEvent domainEvent)
		=> new AddedRegistrationForConferenceEvent()
		{
			UserId = domainEvent.UserId,
			ConferenceId = domainEvent.ConferenceId,
			ConferenceName = domainEvent.ConferenceName,
		};
}
