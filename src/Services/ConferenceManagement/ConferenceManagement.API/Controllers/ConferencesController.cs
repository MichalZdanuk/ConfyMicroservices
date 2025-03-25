using ConferenceManagement.Application.Conferences.BrowseConferences;
using ConferenceManagement.Application.Conferences.CreateConference;
using ConferenceManagement.Application.Conferences.GetConference;
using ConferenceManagement.Application.Conferences.UpdateConfrerence;
using ConferenceManagement.Application.Lectures.AddLecture;

namespace ConferenceManagement.API.Controllers;

[Authorize]
[Route("conferences")]
[ApiController]
public class ConferencesController(IMediator mediator)
	: ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<PaginationResult<ConferenceDto>>> Get([FromQuery] PaginationRequest request)
	{
		var query = new BrowseConferencesQuery(request);

		var result = await mediator.Send(query);

		return Ok(result);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<GetConferenceDto>> GetById(Guid id)
	{
		var query = new GetConferenceQuery(id);

		var result = await mediator.Send(query);

		return result;
	}

	[HttpPost]
	public async Task<ActionResult> CreateConference([FromBody]CreateConferenceDto dto)
	{
		var command = new CreateConferenceCommand(dto.Name,
			dto.Language,
			dto.ConferenceLinksDto,
			dto.ConferenceDetailsDto,
			dto.AddressDto);

		await mediator.Send(command);
		var uri = $"/conferences/{command.Id}";

		return Created(uri, new { Id = command.Id });
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateConference([FromRoute]Guid id, [FromBody]UpdateConferenceDto dto)
	{
		var command = new UpdateConferenceCommand(id,
			dto.Name,
			dto.Language,
			dto.conferenceLinksDto,
			dto.conferenceDetailsDto,
			dto.AddressDto);

		await mediator.Send(command);

		return Accepted();
	}

	[HttpPost("{id}/lectures")]
	public async Task<ActionResult> AddLecture(Guid id, [FromBody]AddLectureDto dto)
	{
		var command = new AddLectureCommand(id, dto.Title, dto.StartDate, dto.EndDate, dto.PrelegentIds);

		await mediator.Send(command);

		return Created();
	}
}
