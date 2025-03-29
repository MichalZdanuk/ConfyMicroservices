namespace Registration.Application.Registrations.BrowseMyRegistratinons;
public record BrowseMyRegistrationsQuery(PaginationRequest Pagination, bool OnlyPending) : IQuery<PaginationResult<UserRegistrationDto>>;
