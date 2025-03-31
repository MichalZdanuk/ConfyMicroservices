using Notification.Domain.Enums;

namespace Notification.Domain.Entities;
public class Notification : Entity
{
	public Guid UserId { get; private set; }
	public NotificationType NotificationType { get; private set; }
	public NotificationStatus NotificationStatus { get; private set; }
	public string Content { get; private set; } = default!;
	public DateTime? SentAt { get; private set; }

	private Notification()
	{
	}

	private Notification(Guid userId,
		NotificationType notificationType,
		string content)
	{
		Id = Guid.NewGuid();
		UserId = userId;
		NotificationType = notificationType;
		NotificationStatus = Enums.NotificationStatus.Created;
		Content = content;
		SentAt = null;
	}

	public static Notification Create(Guid userId,
		NotificationType notificationType,
		string content)
	{
		return new Notification(userId, notificationType, content);
	}

	public void MarkAsSent()
	{
		SentAt = DateTime.UtcNow;
		NotificationStatus = Enums.NotificationStatus.Sent;
	}
}
