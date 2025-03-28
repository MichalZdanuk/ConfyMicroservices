using Shared.Exceptions;

namespace Registration.Domain.Exceptions;
public class CannotCancelAfterStartOfConferenceException
	: BadRequestException
{
	public CannotCancelAfterStartOfConferenceException() : base("Cannot cancel because conference has already been started")
	{
	}
}
