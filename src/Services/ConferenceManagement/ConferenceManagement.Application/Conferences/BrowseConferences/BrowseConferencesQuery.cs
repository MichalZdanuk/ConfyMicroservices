using MediatR;
using Shared.Pagination;

namespace ConferenceManagement.Application.Conference.BrowseConferences;
public record BrowseConferencesQuery(PaginationRequest Pagination) : IRequest<PaginationResult<ConferenceDto>>;
