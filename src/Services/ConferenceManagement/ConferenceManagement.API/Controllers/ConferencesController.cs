using ConferenceManagement.Application.Conference.CreateConference;
using ConferenceManagement.Application.Conference.UpdateConfrerence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManagement.API.Controllers;

[Authorize]
[Route("conferences")]
[ApiController]
public class ConferencesController(IMediator mediator)
	: ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		return Ok("ok");
	}

	[HttpPost]
	public async Task<ActionResult> CreateConference([FromBody]CreateConferenceDto dto)
	{
		var command = new CreateConferenceCommand(dto.Name,
			dto.ConferenceDetailsDto, dto.AddressDto);

		await mediator.Send(command);
		var uri = $"/conferences/{command.Id}";

		return Created(uri, new { Id = command.Id });
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateConference([FromRoute]Guid id, [FromBody]UpdateConferenceDto dto)
	{
		var command = new UpdateConferenceCommand(id, dto.Name,
			dto.ConferenceDetailsDto, dto.AddressDto);

		await mediator.Send(command);

		return Accepted();
	}

}
