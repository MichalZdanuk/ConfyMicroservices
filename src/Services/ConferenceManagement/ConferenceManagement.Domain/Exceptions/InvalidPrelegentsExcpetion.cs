namespace ConferenceManagement.Domain.Exceptions;
public class InvalidPrelegentsExcpetion
	: BadRequestException
{
	public InvalidPrelegentsExcpetion() : base($"Specified prelegents are invalid")
	{
	}
}
