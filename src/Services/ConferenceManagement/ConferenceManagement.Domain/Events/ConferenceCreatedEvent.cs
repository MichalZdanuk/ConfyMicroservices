using Shared.Domain;

namespace ConferenceManagement.Domain.Events;
public record ConferenceCreatedEvent(Guid ConferenceId,
	DateTime StartDate,
	DateTime EndDate,
	string Name) : IDomainEvent;
