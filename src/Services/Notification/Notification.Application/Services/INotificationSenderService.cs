using Notification.Domain.ValueObjects;

namespace Notification.Application.Services;
public interface INotificationSenderService
{
	public Task SendNotificationAsync(NotificationPayload notificationPayload);
	public Task SendNotificationsAsync(IEnumerable<NotificationPayload> notificationPayloads);
}
