namespace Shared.Messaging.Events;
public record PrelegentCreatedEvent : IntegrationEvent
{
	public Guid UserId { get; set; }
	public string Name { get; set; } = default!;
	public string Email { get; set; } = default!;
	public string Bio { get; set; } = default!;
}
