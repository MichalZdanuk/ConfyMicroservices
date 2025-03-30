namespace Registration.Application.Registrations.BrowseMyRegistrations;
public record BrowseMyRegistrationsQuery(PaginationRequest Pagination, bool OnlyPending) : IQuery<PaginationResult<UserRegistrationDto>>;
