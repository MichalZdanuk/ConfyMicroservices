namespace ConferenceManagement.Domain.Entities;
public class Prelegent : Entity
{
	private readonly List<LectureAssignment> _lectureAssignments = new();
	public IReadOnlyList<LectureAssignment> LectureAssignments => _lectureAssignments.AsReadOnly();

	public string Name { get; private set; } = default!;
	public string Bio { get; private set; } = default!;

	private Prelegent()
	{
	}

	public static Prelegent Create(Guid id, string name, string bio)
	{
		return new Prelegent
		{
			Id = id,
			Name = name,
			Bio = bio
		};
	}
}
