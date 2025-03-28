
using Registration.Domain.Repositories;
using Shared.Context;

namespace Registration.Application.Registrations.BrowseMyRegistratinons;
public class BrowseMyRegistrationsQueryHandler(IContext context,
	IRegistrationRepository registrationRepository)
	: IRequestHandler<BrowseMyRegistrationsQuery, PaginationResult<UserRegistrationDto>>
{
	public async Task<PaginationResult<UserRegistrationDto>> Handle(BrowseMyRegistrationsQuery query, CancellationToken cancellationToken)
	{
		var registrations = await registrationRepository.BrowseByUserIdAsync(context.UserId);

		var registrationsDtos = registrations.Select(r => new UserRegistrationDto(
			r.Id,
			r.ConferenceId,
			r.Conference.Name));

		var registrationsCount = await registrationRepository.CountByUserIdAsync(context.UserId);

		return new PaginationResult<UserRegistrationDto>(query.Pagination.PageNumber,
			query.Pagination.PageSize,
			registrationsCount,
			registrationsDtos);
	}
}
