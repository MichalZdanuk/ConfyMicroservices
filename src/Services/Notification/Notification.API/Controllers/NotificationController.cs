using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controllers;

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
