namespace Registration.Domain.Events;
public record UserReRegisteredForConferenceEvent(Guid UserId, Guid ConferenceId, string ConferenceName) : IDomainEvent;
