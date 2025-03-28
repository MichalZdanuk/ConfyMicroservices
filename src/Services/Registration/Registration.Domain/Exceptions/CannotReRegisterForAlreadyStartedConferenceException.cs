namespace Registration.Domain.Exceptions;
public class CannotReRegisterForAlreadyStartedConferenceException
	: BadRequestException
{
	public CannotReRegisterForAlreadyStartedConferenceException(Guid conferenceId) : base($"Cannot re-register because conference {conferenceId} is past or ongoing")
	{
	}
}
