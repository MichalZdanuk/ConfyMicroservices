namespace ConferenceManagement.Domain.Events;
public record CreatedConferenceEvent(Guid ConferenceId,
	DateTime StartDate,
	DateTime EndDate,
	string Name) : IDomainEvent;
