namespace ConferenceManagement.Domain.Entities;
public class Lecture : Aggregate
{
	private readonly List<LectureAssignment> _lectureAssignments = new();
	public IReadOnlyList<LectureAssignment> LectureAssignments => _lectureAssignments.AsReadOnly();

	public Guid ConferenceId { get; private set; }
	public LectureDetails LectureDetails { get; private set; } = default!;

	private Lecture()
	{
	}

	public static Lecture Create(Guid id, Guid conferenceId, LectureDetails details)
	{
		return new Lecture
		{
			Id = id,
			ConferenceId = conferenceId,
			LectureDetails = details
		};
	}

	public void Update(LectureDetails details)
	{
		LectureDetails = details;
	}

	public void AddPrelegent(Guid prelegentId)
	{
		if (!_lectureAssignments.Any(x => x.PrelegentId == prelegentId))
		{
			var assignment = LectureAssignment.Create(Id, prelegentId);
			_lectureAssignments.Add(assignment);
		}
	}

	public void RemovePrelegent(Guid prelegentId)
	{
		var assignment = _lectureAssignments.FirstOrDefault(x => x.PrelegentId == prelegentId);
		if (assignment is not null)
		{
			_lectureAssignments.Remove(assignment);
		}
	}
}
