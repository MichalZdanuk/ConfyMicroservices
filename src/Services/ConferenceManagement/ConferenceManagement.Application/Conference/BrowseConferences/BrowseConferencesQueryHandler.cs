using ConferenceManagement.Domain.DomainService;
using MediatR;

namespace ConferenceManagement.Application.Conference.BrowseConferences;
public class BrowseConferencesQueryHandler(IConferenceDomainService conferenceDomainService)
	: IRequestHandler<BrowseConferencesQuery, IReadOnlyList<ConferenceDto>>
{
	public async Task<IReadOnlyList<ConferenceDto>> Handle(BrowseConferencesQuery query, CancellationToken cancellationToken)
	{
		var conferences = await conferenceDomainService.BrowseConferenceAsync();

		var conferenceDtos = conferences
			.Select(c => new ConferenceDto(
				c.Name,
				new ConferenceDetailsDto(
					c.ConferenceDetails.StartDate,
					c.ConferenceDetails.EndDate,
					c.ConferenceDetails.Description
				),
				new AddressDto(
					c.Address.City,
					c.Address.Country,
					c.Address.AddressLine,
					c.Address.ZipCode
				)
			))
			.ToList();

		return conferenceDtos;
	}

}
