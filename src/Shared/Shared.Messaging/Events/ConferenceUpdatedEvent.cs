namespace Shared.Messaging.Events;
public record ConferenceUpdatedEvent : IntegrationEvent
{
	public Guid ConferenceId { get; set; }
	public string ConferenceName { get; set; } = default!;
}
