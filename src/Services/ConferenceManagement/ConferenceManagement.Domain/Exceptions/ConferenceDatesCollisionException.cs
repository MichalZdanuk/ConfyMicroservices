namespace ConferenceManagement.Domain.Exceptions;
public class ConferenceDatesCollisionException
	: BadRequestException
{
	public ConferenceDatesCollisionException() : base("Ivalid combination of StartDate and EndDate")
	{
	}
}
