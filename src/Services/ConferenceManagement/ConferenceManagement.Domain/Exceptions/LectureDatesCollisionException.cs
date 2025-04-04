namespace ConferenceManagement.Domain.Exceptions;
public class LectureDatesCollisionException
	: BadRequestException
{
	public LectureDatesCollisionException() : base("Ivalid combination of StartDate and EndDate")
	{
	}
}