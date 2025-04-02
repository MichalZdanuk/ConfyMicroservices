


namespace Notification.Infrastructure.Repositories;
public class NotificationRepository(NotificationDbContext context)
	: INotificationRepository
{
	public async Task AddAsync(Domain.Entities.Notification notification)
	{
		await context.Notifications.AddAsync(notification);
	}

	public async Task AddRangeAsync(List<Domain.Entities.Notification> notifications)
	{
		await context.Notifications.AddRangeAsync(notifications);
	}

	public async Task UpdateAsync(Domain.Entities.Notification notification)
	{
		context.Notifications.Update(notification);
	}

	public Task<List<Domain.Entities.Notification>> BrowseByUserIdAsync(Guid userId, int pageNumber, int pageSize)
	{
		var notificationsQuery = context.Notifications
			.Where(n => n.UserId == userId);

		return notificationsQuery
			.OrderByDescending(n => n.CreationDate)
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
	}

	public async Task<int> CountByUserIdAsync(Guid userId)
	{
		return await context.Notifications.CountAsync(n => n.UserId == userId);
	}
}
