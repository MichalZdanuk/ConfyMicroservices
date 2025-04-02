namespace ConferenceManagement.Domain.Exceptions;
public class InvalidConferenceDateException
	: BadRequestException
{
	public InvalidConferenceDateException(DateTime invalidDate) : base($"The conference date '{invalidDate}' is in the past or ongoing. Please select a future date.")
	{
	}
}
