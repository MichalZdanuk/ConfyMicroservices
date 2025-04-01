namespace Notification.Application.Services;
public interface INotificationService
{
	public Task SendNotification(Domain.Entities.Notification notification);
}
