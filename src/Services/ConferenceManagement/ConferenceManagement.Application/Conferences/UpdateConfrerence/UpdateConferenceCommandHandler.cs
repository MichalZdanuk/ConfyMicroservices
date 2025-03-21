using ConferenceManagement.Domain.Data;
using ConferenceManagement.Domain.Exceptions;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Domain.ValueObjects;
using MediatR;

namespace ConferenceManagement.Application.Conference.UpdateConfrerence;
public class UpdateCommandHandler(IConferenceRepository conferenceRepository,
	IDbContext dbContext)
	: IRequestHandler<UpdateConferenceCommand>
{
	public async Task Handle(UpdateConferenceCommand command, CancellationToken cancellationToken)
	{
		var conference = await conferenceRepository.GetByIdAsync(command.ConferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(command.ConferenceId);
		}

		var updatedConferenceDetails = ConferenceDetails.Of(command.ConferenceDetails.StartDate,
			command.ConferenceDetails.EndDate,
			command.ConferenceDetails.Description);

		var updatedAddress = Address.Of(command.Address.City,
			command.Address.Country,
			command.Address.AddressLine,
			command.Address.ZipCode);

		conference.Update(command.Name, updatedConferenceDetails, updatedAddress);

		await conferenceRepository.UpdateAsync(conference);
		await dbContext.SaveChangesAsync();
	}
}
