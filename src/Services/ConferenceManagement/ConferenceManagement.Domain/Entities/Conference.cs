namespace ConferenceManagement.Domain.Entities;
public class Conference : Aggregate
{
	private readonly List<Guid> _lectureIds = new();
	public IReadOnlyList<Guid> LectureIds => _lectureIds.AsReadOnly();
	public string Name {  get; private set; } = default!;
	public ConferenceLanguage ConferenceLanguage { get; private set; } = default!;
	public ConferenceLinks ConferenceLinks { get; private set; } = default!;
	public ConferenceDetails ConferenceDetails { get; private set; } = default!;
	public Address Address { get; private set; } = default!;

	public static Conference Create(Guid id,
		string name,
		ConferenceLanguage conferenceLanguage,
		ConferenceLinks conferenceLinks,
		ConferenceDetails details,
		Address address)
	{
		var conference = new Conference
		{
			Id = id,
			Name = name,
			ConferenceLanguage = conferenceLanguage,
			ConferenceLinks = conferenceLinks,
			ConferenceDetails = details,
			Address = address
		};

		conference.AddDomainEvent(new CreatedConferenceEvent(conference.Id,
			conference.ConferenceDetails.StartDate,
			conference.ConferenceDetails.EndDate,
			conference.Name));

		return conference;
	}

	public void Update(string name,
		ConferenceLanguage conferenceLanguage,
		ConferenceLinks conferenceLinks,	
		ConferenceDetails details,
		Address address)
	{
		Name = name;
		ConferenceLanguage = conferenceLanguage;
		ConferenceLinks = conferenceLinks;
		ConferenceDetails = details;
		Address = address;

		AddDomainEvent(new UpdatedConferenceEvent(Id, Name));
	}

	public void AddLecture(Guid lectureId)
	{
		if (!_lectureIds.Contains(lectureId))
		{
			_lectureIds.Add(lectureId);
		}
	}

	public void RemoveLecture(Guid lectureId)
	{
		if (_lectureIds.Contains(lectureId))
		{
			_lectureIds.Remove(lectureId);
		}
	}
}
