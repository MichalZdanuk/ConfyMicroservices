namespace Registration.Domain.Events;
public record RegistrationForConferenceCanceledEvent(Guid UserId, Guid ConferenceId) : IDomainEvent;
