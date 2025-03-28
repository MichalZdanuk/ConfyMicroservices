namespace Registration.Domain.Exceptions;
public class CannotCancelAlreadyCancelledRegistrationException
	: BadRequestException
{
	public CannotCancelAlreadyCancelledRegistrationException(Guid conferenceId) : base($"Registration for conference {conferenceId} was already cancelled")
	{
	}
}
