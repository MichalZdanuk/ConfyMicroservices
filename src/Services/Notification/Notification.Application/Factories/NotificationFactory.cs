using Notification.Application.Providers;
using Notification.Domain.Enums;

namespace Notification.Application.Factories;
public class NotificationFactory(INotificationTemplateProvider notificationTemplateProvider)
	: INotificationFactory
{
	public Domain.Entities.Notification CreateNotification(Guid userId, Guid conferenceId, NotificationType type, string conferenceName)
	{
		var message = notificationTemplateProvider.GetNotificationTemplate(type)
			.Replace("{ConferenceName}", conferenceName);

		var notification = Domain.Entities.Notification.Create(userId, conferenceId, type, message);
		notification.MarkAsSent();

		return notification;
	}

	public List<Domain.Entities.Notification> CreateNotifications(IEnumerable<Guid> userIds, Guid conferenceId, NotificationType type, string conferenceName)
	{
		var notifications = new List<Domain.Entities.Notification>();
		var message = notificationTemplateProvider.GetNotificationTemplate(type)
			.Replace("{ConferenceName}", conferenceName);

		foreach (var userId in userIds)
		{
			var notification = Domain.Entities.Notification.Create(userId, conferenceId, type, message);
			notification.MarkAsSent();
			notifications.Add(notification);
		}

		return notifications;
	}
}
