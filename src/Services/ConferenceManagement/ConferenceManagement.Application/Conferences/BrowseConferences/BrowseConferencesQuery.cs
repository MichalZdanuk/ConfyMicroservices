using MediatR;
using Shared.CQRS;
using Shared.Pagination;

namespace ConferenceManagement.Application.Conference.BrowseConferences;
public record BrowseConferencesQuery(PaginationRequest Pagination) : IQuery<PaginationResult<ConferenceDto>>;
