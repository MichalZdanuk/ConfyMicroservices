using MediatR;

namespace Shared.Domain;
public interface IDomainEvent : INotification
{
	Guid EventId => Guid.NewGuid();
	public DateTime OccurredAt => DateTime.UtcNow;
	public string EventType => GetType().AssemblyQualifiedName!;
}
