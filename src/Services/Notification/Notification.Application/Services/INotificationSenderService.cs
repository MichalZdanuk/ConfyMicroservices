namespace Notification.Application.Services;
public interface INotificationSenderService
{
	public Task SendNotification(NotificationPayload notificationPayload);
	public Task SendNotifications(IEnumerable<NotificationPayload> notificationPayloads);
}
