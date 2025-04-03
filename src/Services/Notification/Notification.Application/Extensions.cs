using Notification.Domain.ValueObjects;

namespace Notification.Application;
public static class Extensions
{
	public static NotificationPayload MapToPayload(this Domain.Entities.Notification notification, string email)
	{
		return new NotificationPayload(
			notification.NotificationType.ToString(),
			email,
			notification.Content,
			notification.SentAt ?? DateTime.UtcNow
		);
	}
}
