namespace ConferenceManagement.Application.Lectures.AddLecture;
public class AddLectureCommandHandler(IConferenceRepository conferenceRepository,
	IPrelegentRepository prelegentRepository,
	ILectureRepository lectureRepository)
	: IRequestHandler<AddLectureCommand>
{
	public async Task Handle(AddLectureCommand command, CancellationToken cancellationToken)
	{
		var conference = await conferenceRepository.GetByIdAsync(command.ConferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(command.ConferenceId);
		}

		await ValidatePrelegents(command.PrelegentIds);

		var lecture = RetrieveLectureFromCommand(command);

		conference.AddLecture(lecture.Id);

		await conferenceRepository.UpdateAsync(conference);
		await lectureRepository.AddAsync(lecture);
	}

	private async Task ValidatePrelegents(IList<Guid> prelegentIds)
	{
		var exists = await prelegentRepository.AllPrelegentsExistAsync(prelegentIds);

		if (!exists)
		{
			throw new InvalidPrelegentsExcpetion();
		}
	}

	private Lecture RetrieveLectureFromCommand(AddLectureCommand command)
	{
		var lectureDetails = LectureDetails.Of(command.Title,
			command.StartDate,
			command.EndDate);

		var lecture = Lecture.Create(command.Id,
			command.ConferenceId, lectureDetails);

		foreach (var prelegentId in command.PrelegentIds)
		{
			lecture.AddPrelegent(prelegentId);
		}

		return lecture;
	}
}
