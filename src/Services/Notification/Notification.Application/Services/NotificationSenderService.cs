using Microsoft.Extensions.Logging;

namespace Notification.Application.Services;
public class NotificationSenderService(ILogger<NotificationSenderService> logger)
	: INotificationSenderService
{
	public async Task SendNotification(NotificationPayload notificationPayload)
	{
		logger.LogInformation($"[MOCKED] successfully sent notification (type: {notificationPayload.NotificationType}) for: {notificationPayload.Email} with content: `{notificationPayload.Content}` at [{notificationPayload.SentAt}]");
	
		await Task.CompletedTask;
	}
}
