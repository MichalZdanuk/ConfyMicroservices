using Shared.Enums;

namespace Shared.Messaging.Events;
public record UserRegisteredEvent : IntegrationEvent
{
	public Guid UserId { get; set; }
	public string FirstName { get; set; } = default!;
	public string LastName { get; set; } = default!;
	public string Email { get; set; } = default!;
	public UserRole UserRole { get; set; }
}
