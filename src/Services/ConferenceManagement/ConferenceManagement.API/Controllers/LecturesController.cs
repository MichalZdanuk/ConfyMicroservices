using ConferenceManagement.Application.Lectures.UpdateLecture;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
}
