namespace ConferenceManagement.Domain.Exceptions;
public class InvalidLectureDateException
	: BadRequestException
{
	public InvalidLectureDateException(DateTime invalidDate) : base($"The lecture date '{invalidDate}' is in the past or ongoing. Please select a future date.")
	{
	}
}