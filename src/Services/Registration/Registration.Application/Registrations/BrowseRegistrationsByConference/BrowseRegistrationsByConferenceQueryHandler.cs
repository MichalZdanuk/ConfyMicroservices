using Registration.Domain.Repositories;

namespace Registration.Application.Registrations.BrowseRegistrationsByConference;
public class BrowseRegistrationsByConferenceQueryHandler(IRegistrationRepository registrationRepository)
	: IRequestHandler<BrowseRegistrationsByConferenceQuery, IReadOnlyList<ConferenceRegistrationDto>>
{
	public async Task<IReadOnlyList<ConferenceRegistrationDto>> Handle(BrowseRegistrationsByConferenceQuery query, CancellationToken cancellationToken)
	{
		var registrations = await registrationRepository.BrowseByConferenceIdAsync(query.ConferenceId, query.Statuses);

		var registrationsDtos = registrations.Select(r => new ConferenceRegistrationDto(r.Id, r.UserId, r.RegistrationStatus)).ToList();

		return registrationsDtos;
	}
}
