﻿namespace Registration.Application.Registrations.BrowseRegistrationsByConference;
public record BrowseRegistrationsByConferenceQuery(Guid ConferenceId) : IQuery<IReadOnlyList<ConferenceRegistrationDto>>;
