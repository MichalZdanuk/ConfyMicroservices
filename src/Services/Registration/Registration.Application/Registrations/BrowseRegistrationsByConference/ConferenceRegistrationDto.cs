using Shared.Enums;

namespace Registration.Application.Registrations.BrowseRegistrationsByConference;
public record ConferenceRegistrationDto(Guid RegistrationId, Guid UserId, RegistrationStatus RegistrationStatus);
