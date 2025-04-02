using Notification.Domain.Enums;

namespace Notification.Application.Providers;
public class NotificationTemplateProvider
	: INotificationTemplateProvider
{
	private readonly Dictionary<NotificationType, string> _templates = new()
		{
			{ NotificationType.Registration, "You have successfully registered for the conference \"{ConferenceName}\". We look forward to seeing you there!" },
			{ NotificationType.RegistrationCanceled, "Your registration for the conference \"{ConferenceName}\" has been canceled. We hope to see you at a future event!" },
			{ NotificationType.ConferenceUpdated, "There’s an important update regarding conference: \"{ConferenceName}\". Please check the latest details." }
		};

	public string GetNotificationTemplate(NotificationType type)
	{
		return _templates.TryGetValue(type, out var template) ? template : throw new Exception("Cannot find notification template");
	}
}
