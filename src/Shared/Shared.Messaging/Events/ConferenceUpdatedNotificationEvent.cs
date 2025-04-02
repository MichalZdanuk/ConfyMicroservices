namespace Shared.Messaging.Events;
public record ConferenceUpdatedNotificationEvent : IntegrationEvent
{
	public Guid ConferenceId { get; set; }
	public string ConferenceName { get; set; } = default!;
	public List<Guid> UserIds { get; init; } = [];
}
