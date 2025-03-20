using ConferenceManagement.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ConferenceManagement.Application.EventHandlers.Domain;
public class ConferenceCreatedEventHandler(ILogger<ConferenceCreatedEventHandler> logger)
	: INotificationHandler<ConferenceCreatedEvent>
{
	public Task Handle(ConferenceCreatedEvent domainEvent, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain event handled: {domainEvent}", domainEvent.GetType().Name);

		return Task.CompletedTask;
	}
}
