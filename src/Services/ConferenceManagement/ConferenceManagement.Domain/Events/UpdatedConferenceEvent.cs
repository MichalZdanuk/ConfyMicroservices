namespace ConferenceManagement.Domain.Events;
public record UpdatedConferenceEvent(Guid ConferenceId, string ConferenceName) : IDomainEvent;
