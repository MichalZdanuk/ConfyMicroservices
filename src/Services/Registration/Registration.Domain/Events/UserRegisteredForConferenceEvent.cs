namespace Registration.Domain.Events;
public record UserRegisteredForConferenceEvent(Guid UserId, Guid ConferenceId) : IDomainEvent;
