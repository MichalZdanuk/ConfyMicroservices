

namespace Notification.Infrastructure.Repositories;
public class NotificationRepository(NotificationDbContext context)
	: INotificationRepository
{
	public async Task AddAsync(Domain.Entities.Notification notification)
	{
		await context.Notifications.AddAsync(notification);
	}

	public async Task<Domain.Entities.Notification?> GetByIdAsync(Guid id)
	{
		return await context.Notifications.SingleOrDefaultAsync(notification => notification.Id == id);
	}

	public async Task UpdateAsync(Domain.Entities.Notification notification)
	{
		context.Notifications.Update(notification);
	}
}
