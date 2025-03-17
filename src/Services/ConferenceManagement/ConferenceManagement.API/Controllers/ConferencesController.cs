using Microsoft.AspNetCore.Mvc;

namespace ConferenceManagement.API.Controllers;

[Route("conferences")]
[ApiController]
public class ConferencesController : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		return Ok("ok");
	}
}
