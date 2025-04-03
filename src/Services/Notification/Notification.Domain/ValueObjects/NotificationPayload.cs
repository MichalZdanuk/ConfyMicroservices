namespace Notification.Domain.ValueObjects;

public record NotificationPayload(string NotificationType, string Email, string Content, DateTime SentAt);
