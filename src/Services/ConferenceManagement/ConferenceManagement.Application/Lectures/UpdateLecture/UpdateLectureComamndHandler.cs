namespace ConferenceManagement.Application.Lectures.UpdateLecture;
public class UpdateLectureComamndHandler(ILectureRepository lectureRepository)
	: IRequestHandler<UpdateLectureCommand>
{
	public async Task Handle(UpdateLectureCommand command, CancellationToken cancellationToken)
	{
		var lecture = await lectureRepository.GetByIdAsync(command.LectureId);

		if (lecture is null)
		{
			throw new LectureNotFoundException(command.LectureId);
		}

		var updatedLectureDetails = LectureDetails.Of(command.Title,
			command.StartDate,
			command.EndDate);

		lecture.Update(updatedLectureDetails);

		await lectureRepository.UpdateAsync(lecture);
	}
}
