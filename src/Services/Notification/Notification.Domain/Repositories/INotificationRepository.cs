namespace Notification.Domain.Repositories;
public interface INotificationRepository
{
	public Task AddAsync(Entities.Notification notification);
}
