namespace Notification.Application.Services;
public interface INotificationSenderService
{
	public Task SendNotification(NotificationPayload notificationPayload);
}
