using ConferenceManagement.Application.Lectures.UpdateLecture;
using ConferenceManagement.Application.Lectures.UpdateLecturePrelegents;

namespace ConferenceManagement.API.Controllers;

[Authorize]
[Route("lectures")]
[ApiController]
public class LecturesController(IMediator mediator)
	: ControllerBase
{
	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateLecture(Guid id, [FromBody]UpdateLectureDto dto)
	{
		var command = new UpdateLectureCommand(id,
			dto.Title,
			dto.StartDate,
			dto.EndDate);

		await mediator.Send(command);

		return Accepted();
	}

	[HttpPut("{id}/prelegents")]
	public async Task<ActionResult> UpdateLecturePrelegents(Guid id, [FromBody]UpdateLecturePrelegentsDto dto)
	{
		var command = new UpdateLecturePrelegentsCommand(id, dto.PrelegentIds);

		await mediator.Send(command);


		return Accepted();
	}
}
