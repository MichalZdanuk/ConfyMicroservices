using Shared.Domain;

namespace ConferenceManagement.Domain.Entities;
public class LectureAssignment : Entity
{
	public Guid LectureId { get; private set; }
	public Guid PrelegentId { get; private set; }

	private LectureAssignment()
	{
	}

	public static LectureAssignment Create(Guid lectureId, Guid prelegentId)
	{
		return new LectureAssignment
		{
			LectureId = lectureId,
			PrelegentId = prelegentId
		};
	}
}
