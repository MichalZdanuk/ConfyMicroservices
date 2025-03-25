namespace Shared.Messaging.Events;
public record ConferenceCreatedEvent : IntegrationEvent
{
	public Guid ConferenceId { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string Name { get; set; } = default!;
}
