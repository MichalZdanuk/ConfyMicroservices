using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Registrations.AddRegistration;
using Registration.Application.Registrations.BrowseMyRegistrations;
using Registration.Application.Registrations.BrowseRegistrationsByConference;
using Registration.Application.Registrations.CancelRegistration;
using Shared.Enums;
using Shared.Pagination;

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

		var registrationId = await mediator.Send(command);

		var uri = $"/registrations/{registrationId}";

		return Created(uri, new { Id = registrationId });
	}

	[HttpPut("{id}/cancel")]
	public async Task<ActionResult> CancelRegistration([FromRoute] Guid id)
	{
		var command = new CancelRegistrationCommand(id);

		await mediator.Send(command);

		return Accepted();
	}

	[HttpGet]
	public async Task<ActionResult<PaginationResult<UserRegistrationDto>>> BrowseMyRegistrations([FromQuery] PaginationRequest request,
		bool onlyPending = false)
	{
		var query = new BrowseMyRegistrationsQuery(request, onlyPending);

		var result = await mediator.Send(query);

		return Ok(result);
	}

	[HttpGet("conference/{conferenceId}")]
	public async Task<ActionResult<IReadOnlyList<ConferenceRegistrationDto>>> BrowseRegistrationsByConference([FromRoute] Guid conferenceId,
		[FromQuery] List<RegistrationStatus> statuses)
	{
		var query = new BrowseRegistrationsByConferenceQuery(conferenceId, statuses ?? new List<RegistrationStatus>());

		var result = await mediator.Send(query);

		return Ok(result);
	}
}
