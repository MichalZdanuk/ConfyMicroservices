using Notification.Domain.Enums;

namespace Notification.Application.Factories;
public interface INotificationFactory
{
	Domain.Entities.Notification CreateNotification(Guid userId, Guid conferenceId, NotificationType type, string conferenceName);
	List<Domain.Entities.Notification> CreateNotifications(IEnumerable<Guid> userIds, Guid conferenceId, NotificationType type, string conferenceName);
}
