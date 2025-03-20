using ConferenceManagement.Application.Conference.CreateConference;
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

}
