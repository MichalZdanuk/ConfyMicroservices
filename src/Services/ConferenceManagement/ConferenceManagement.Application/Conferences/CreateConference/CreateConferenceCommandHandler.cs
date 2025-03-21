using ConferenceManagement.Domain.Data;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.ValueObjects;
using MediatR;

namespace ConferenceManagement.Application.Conference.CreateConference;
public class CreateConferenceCommandHandler(IConferenceRepository conferenceRepository,
	IDbContext dbContext)
	: IRequestHandler<CreateConferenceCommand>
{
	public async Task Handle(CreateConferenceCommand command, CancellationToken cancellationToken)
	{
		var conference = RetrieveConferenceFromCommand(command);

		await conferenceRepository.AddAsync(conference);

		await dbContext.SaveChangesAsync();
	}

	private ConferenceManagement.Domain.Entities.Conference RetrieveConferenceFromCommand(CreateConferenceCommand command)
	{
		var conferenceDetails = ConferenceDetails.Of(command.ConferenceDetails.StartDate,
			command.ConferenceDetails.EndDate,
			command.ConferenceDetails.Description);

		var address = Address.Of(command.Address.City,
			command.Address.Country,
			command.Address.AddressLine,
			command.Address.ZipCode);

		var conference = ConferenceManagement.Domain.Entities.Conference.Create(command.Id, command.Name, conferenceDetails, address);

		return conference;
	}
}
