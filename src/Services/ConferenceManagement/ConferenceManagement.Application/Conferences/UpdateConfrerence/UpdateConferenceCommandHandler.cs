namespace ConferenceManagement.Application.Conferences.UpdateConfrerence;
public class UpdateConferenceCommandHandler(IConferenceRepository conferenceRepository)
	: IRequestHandler<UpdateConferenceCommand>
{
	public async Task Handle(UpdateConferenceCommand command, CancellationToken cancellationToken)
	{
		var conference = await conferenceRepository.GetByIdAsync(command.ConferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(command.ConferenceId);
		}

		if (conference.ConferenceDetails.StartDate >= DateTime.UtcNow)
		{
			throw new CannotModifyActiveConferenceException(conference.Id);
		}

		var updatedConferenceLinks = ConferenceLinks.Of(command.ConferenceLinks.WebsiteUrl,
			command.ConferenceLinks.FacebookUrl,
			command.ConferenceLinks.InstagramUrl);

		var updatedConferenceDetails = ConferenceDetails.Of(conference.ConferenceDetails.StartDate,
			conference.ConferenceDetails.EndDate,
			command.ConferenceDetails.Description,
			command.ConferenceDetails.IsOnline);

		var updatedAddress = Address.Of(command.Address.City,
			command.Address.Country,
			command.Address.AddressLine,
			command.Address.ZipCode);

		conference.Update(conference.Name, command.ConferenceLanguage, updatedConferenceLinks, updatedConferenceDetails, updatedAddress);

		await conferenceRepository.UpdateAsync(conference);
	}
}
