using ConferenceManagement.Domain.ValueObjects;
using Shared.Domain;

namespace ConferenceManagement.Domain.Entities;
public class Lecture : Aggregate
{
	private readonly List<Guid> _prelegentIds = new();
	public IReadOnlyList<Guid> PrelegentIds => _prelegentIds.AsReadOnly();

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

	public void AddPrelegent(Guid prelegentId)
	{
		if (!_prelegentIds.Contains(prelegentId))
		{
			_prelegentIds.Add(prelegentId);
		}
	}

	public void RemovePrelegent(Guid prelegentId)
	{
		if (_prelegentIds.Contains(prelegentId))
		{
			_prelegentIds.Remove(prelegentId);
		}
	}
}
