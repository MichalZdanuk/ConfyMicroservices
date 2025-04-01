namespace Shared.Messaging.Events;
public record CanceledRegistrationForConferenceEvent : IntegrationEvent
{
	public Guid ConferenceId { get; set; }
	public Guid UserId { get; set; }
	public string ConferenceName { get; set; } = default!;
}
