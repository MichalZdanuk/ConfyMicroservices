using MediatR;
using Notification.Application.Notifications.BrowseMyNotifications;
using Shared.Pagination;

namespace Notification.API.Controllers;

[Authorize]
[Route("notifications")]
[ApiController]
public class NotificationsController(IMediator mediator)
	: ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<PaginationResult<NotificationDto>>> BrowseMyNotifications([FromQuery] PaginationRequest request)
	{
		var query = new BrowseMyNotificationsQuery(request);

		var result = await mediator.Send(query);

		return Ok(result);
	}
}
