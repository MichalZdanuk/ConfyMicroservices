using ConferenceManagement.Domain.DomainService;
using ConferenceManagement.Domain.ValueObjects;
using MediatR;

namespace ConferenceManagement.Application.Conference.UpdateConfrerence;
public class UpdateCommandHandler(IConferenceDomainService conferenceDomainService)
	: IRequestHandler<UpdateConferenceCommand>
{
	public async Task Handle(UpdateConferenceCommand command, CancellationToken cancellationToken)
	{
		var conferenceDetails = ConferenceDetails.Of(command.ConferenceDetails.StartDate,
			command.ConferenceDetails.EndDate,
			command.ConferenceDetails.Description);

		var address = Address.Of(command.Address.City,
			command.Address.Country,
			command.Address.AddressLine,
			command.Address.ZipCode);

		await conferenceDomainService.UpdateConferenceAsync(command.ConferenceId, command.Name, conferenceDetails, address);
	}
}
