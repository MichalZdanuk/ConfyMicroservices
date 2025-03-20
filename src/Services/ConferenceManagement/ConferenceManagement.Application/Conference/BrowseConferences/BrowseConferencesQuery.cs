using MediatR;

namespace ConferenceManagement.Application.Conference.BrowseConferences;
public class BrowseConferencesQuery() : IRequest<IReadOnlyList<ConferenceDto>>;
