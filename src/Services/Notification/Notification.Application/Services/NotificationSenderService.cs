using Microsoft.Extensions.Logging;
using Notification.Domain.ValueObjects;

namespace Notification.Application.Services;
public class NotificationSenderService(ILogger<NotificationSenderService> logger)
	: INotificationSenderService
{
	public async Task SendNotification(NotificationPayload notificationPayload)
	{
		logger.LogInformation($"[MOCKED] successfully sent notification (type: {notificationPayload.NotificationType}) for: {notificationPayload.Email} with content: `{notificationPayload.Content}` at [{notificationPayload.SentAt}]");
	
		await Task.CompletedTask;
	}

	public async Task SendNotifications(IEnumerable<NotificationPayload> notificationPayloads)
	{
		foreach (var payload in notificationPayloads)
		{
			logger.LogInformation($"[MOCKED] successfully sent notification (type: {payload.NotificationType}) for: {payload.Email} with content: `{payload.Content}` at [{payload.SentAt}]");
		}

		await Task.CompletedTask;
	}
}
