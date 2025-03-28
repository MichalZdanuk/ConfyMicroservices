namespace Registration.Application.Registrations.BrowseMyRegistratinons;
public record BrowseMyRegistrationsQuery(PaginationRequest Pagination) : IQuery<PaginationResult<UserRegistrationDto>>;
