namespace Shared.Messaging.Events;
public record IntegrationEvent
{
	public Guid Id => Guid.NewGuid();
	public DateTime OccuredAt => DateTime.UtcNow;
	public string EventType => GetType().AssemblyQualifiedName;
}
