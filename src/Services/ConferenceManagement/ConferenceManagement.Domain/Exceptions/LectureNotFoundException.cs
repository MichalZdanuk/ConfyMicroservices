namespace ConferenceManagement.Domain.Exceptions;
public class LectureNotFoundException
	: NotFoundException
{
	public LectureNotFoundException(Guid lectureId) : base($"Lecture: {lectureId} was not found")
	{
	}
}
