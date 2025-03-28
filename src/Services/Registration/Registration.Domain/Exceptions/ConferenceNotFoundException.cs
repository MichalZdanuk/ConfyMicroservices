namespace Registration.Domain.Exceptions;
public class ConferenceNotFoundException
	: NotFoundException
{
	public ConferenceNotFoundException(Guid conferenceId) : base($"Conference with id: {conferenceId} was not found")
	{
	}
}
