using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Registrations.AddRegistration;
using Registration.Application.Registrations.CancelRegistration;

namespace Registration.API.Controllers;

[Authorize]
[Route("registrations")]
[ApiController]
public class RegistrationController(IMediator mediator)
	: ControllerBase
{
	[HttpPost]
	public async Task<ActionResult> AddRegistration([FromBody] AddRegistrationDto dto)
	{
		var command = new AddRegistrationCommand(dto.ConferenceId);

		await mediator.Send(command);

		var uri = $"/registrations/{command.Id}";

		return Created(uri, new { Id = command.Id });
	}

	[HttpPut("{id}/cancel")]
	public async Task<ActionResult> CancelRegistration([FromRoute] Guid id)
	{
		var command = new CancelRegistrationCommand(id);

		await mediator.Send(command);

		return Accepted();
	}
}
