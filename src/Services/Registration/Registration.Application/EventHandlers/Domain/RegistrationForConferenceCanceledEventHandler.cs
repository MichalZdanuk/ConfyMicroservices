using MassTransit;
using Microsoft.Extensions.Logging;
using Registration.Domain.Events;
using Shared.Messaging.Events;

namespace Registration.Application.EventHandlers.Domain;
public class RegistrationForConferenceCanceledEventHandler(ILogger<RegistrationForConferenceCanceledEventHandler> logger,
	IPublishEndpoint publishEndpoint)
	: INotificationHandler<RegistrationForConferenceCanceledEvent>
{
	public async Task Handle(RegistrationForConferenceCanceledEvent domainEvent, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain event handled: {domainEvent}", domainEvent.GetType().Name);

		var canceledRegistrationForConferenceEvent = RetrieveCanceledRegistrationForConferenceEvent(domainEvent);

		await publishEndpoint.Publish(canceledRegistrationForConferenceEvent, cancellationToken);
	}

	private CanceledRegistrationForConferenceEvent RetrieveCanceledRegistrationForConferenceEvent(RegistrationForConferenceCanceledEvent domainEvent)
		=> new CanceledRegistrationForConferenceEvent()
		{
			UserId = domainEvent.UserId,
			ConferenceId = domainEvent.ConferenceId,
			ConferenceName = domainEvent.ConferenceName,
		};
}
