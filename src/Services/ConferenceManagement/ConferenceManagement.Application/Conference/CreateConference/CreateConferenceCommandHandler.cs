using ConferenceManagement.Domain.DomainService;
using ConferenceManagement.Domain.ValueObjects;
using MediatR;

namespace ConferenceManagement.Application.Conference.CreateConference;
public class CreateConferenceCommandHandler(IConferenceDomainService conferenceDomainService)
	: IRequestHandler<CreateConferenceCommand>
{
	public async Task Handle(CreateConferenceCommand command, CancellationToken cancellationToken)
	{
		var conferenceDetails = ConferenceDetails.Of(command.ConferenceDetails.StartDate,
			command.ConferenceDetails.EndDate,
			command.ConferenceDetails.Description);

		var address = Address.Of(command.Address.City,
			command.Address.Country,
			command.Address.AddressLine,
			command.Address.ZipCode);

		await conferenceDomainService.CreateConferenceAsync(command.Id, command.Name, conferenceDetails, address);
	}
}
