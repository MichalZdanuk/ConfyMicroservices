namespace Notification.Infrastructure.Repositories;
public class NotificationRepository(NotificationDbContext context)
	: INotificationRepository
{
	public async Task AddAsync(Domain.Entities.Notification notification)
	{
		await context.Notifications.AddAsync(notification);
	}
}
