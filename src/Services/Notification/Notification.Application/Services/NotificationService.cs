using Microsoft.Extensions.Logging;

namespace Notification.Application.Services;
public class NotificationService(ILogger<NotificationService> logger)
	: INotificationService
{
	public async Task SendNotification(Domain.Entities.Notification notification)
	{
		logger.LogInformation($"[MOCKED] successfully sent notification (type: {notification.NotificationType.ToString()}) for user: {notification.UserId} with content: {notification.Content} at [{notification.SentAt}]");
	
		await Task.CompletedTask;
	}
}
