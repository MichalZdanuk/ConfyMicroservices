namespace Registration.Domain.Exceptions;
public class CannotReRegisterForNotCancelledConferenceRegistrationException
	: BadRequestException
{
	public CannotReRegisterForNotCancelledConferenceRegistrationException(Guid conferenceId) : base($"Cannot re-register to conference: {conferenceId} because it is not cancelled")
	{
	}
}
