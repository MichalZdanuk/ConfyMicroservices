namespace ConferenceManagement.Application.Conferences.BrowseConferences;
public record BrowseConferencesQuery(PaginationRequest Pagination) : IQuery<PaginationResult<ConferenceDto>>;
