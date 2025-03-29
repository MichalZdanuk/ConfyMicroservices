namespace ConferenceManagement.Application.Conferences.CreateConference;
public class CreateConferenceCommandHandler(IConferenceRepository conferenceRepository)
	: IRequestHandler<CreateConferenceCommand>
{
	public async Task Handle(CreateConferenceCommand command, CancellationToken cancellationToken)
	{
		var conference = RetrieveConferenceFromCommand(command);

		await conferenceRepository.AddAsync(conference);
	}

	private Conference RetrieveConferenceFromCommand(CreateConferenceCommand command)
	{
		var conferenceLinks = ConferenceLinks.Of(command.ConferenceLinks.WebsiteUrl,
			command.ConferenceLinks.FacebookUrl,
			command.ConferenceLinks.InstagramUrl);

		var conferenceDetails = ConferenceDetails.Of(command.ConferenceDetails.StartDate,
			command.ConferenceDetails.EndDate,
			command.ConferenceDetails.Description,
			command.ConferenceDetails.IsOnline);

		var address = Address.Of(command.Address.City,
			command.Address.Country,
			command.Address.AddressLine,
			command.Address.ZipCode);

		var conference = Conference.Create(command.Id,
			command.Name,
			command.ConferenceLanguage,
			conferenceLinks,
			conferenceDetails,
			address);

		return conference;
	}
}
