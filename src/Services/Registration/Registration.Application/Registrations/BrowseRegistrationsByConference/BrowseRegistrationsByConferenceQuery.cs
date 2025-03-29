using Shared.Enums;

namespace Registration.Application.Registrations.BrowseRegistrationsByConference;
public record BrowseRegistrationsByConferenceQuery(Guid ConferenceId, List<RegistrationStatus> Statuses) : IQuery<IReadOnlyList<ConferenceRegistrationDto>>;
