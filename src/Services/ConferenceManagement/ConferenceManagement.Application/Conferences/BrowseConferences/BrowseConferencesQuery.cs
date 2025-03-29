using Shared.Enums;

namespace ConferenceManagement.Application.Conferences.BrowseConferences;
public record BrowseConferencesQuery(PaginationRequest Pagination, List<ConferenceLanguage> Languages,
	bool? IsOnline = null, string? Country = null,
	DateTime? StartDate = null, DateTime? EndDate = null) : IQuery<PaginationResult<ConferenceDto>>;
