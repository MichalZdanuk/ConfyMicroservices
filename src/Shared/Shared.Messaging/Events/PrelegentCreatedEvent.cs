namespace Shared.Messaging.Events;
public record PrelegentCreatedEvent : IntegrationEvent
{
	public Guid UserId { get; set; }
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public string Email { get; set; } = default!;
}
