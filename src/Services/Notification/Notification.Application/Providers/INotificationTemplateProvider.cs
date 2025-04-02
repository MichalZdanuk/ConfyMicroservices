using Notification.Domain.Enums;

namespace Notification.Application.Providers;
public interface INotificationTemplateProvider
{
	public string GetNotificationTemplate(NotificationType type);
}
