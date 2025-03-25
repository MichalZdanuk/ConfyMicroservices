namespace ConferenceManagement.Application.Lectures.UpdateLecturePrelegents;
public class UpdateLecturePrelegentsCommandHandler(ILectureRepository lectureRepository,
	IPrelegentRepository prelegentRepository)
	: IRequestHandler<UpdateLecturePrelegentsCommand>
{
	public async Task Handle(UpdateLecturePrelegentsCommand command, CancellationToken cancellationToken)
	{
		var lecture = await lectureRepository.GetWithAssignmentsByIdAsync(command.LectureId);

		if (lecture is null)
		{
			throw new LectureNotFoundException(command.LectureId);
		}

		await ValidatePrelegents(command.PrelegentIds);

		lecture.UpdatePrelegents(command.PrelegentIds);

		await lectureRepository.UpdateAsync(lecture);
	}

	private async Task ValidatePrelegents(IList<Guid> prelegentIds)
	{
		var exists = await prelegentRepository.AllPrelegentsExistAsync(prelegentIds);

		if (!exists)
		{
			throw new InvalidPrelegentsExcpetion();
		}
	}
}
