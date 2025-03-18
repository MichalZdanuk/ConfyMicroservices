using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controllers;

[Authorize]
[Route("notifications")]
[ApiController]
public class NotificationController
	: ControllerBase
{
	[HttpGet("test")]
	public async Task<IActionResult> Get()
	{
		return Ok("ok");
	}
}
