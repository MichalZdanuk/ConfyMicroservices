namespace Notification.Domain.Repositories;
public interface INotificationRepository
{
	public Task AddAsync(Entities.Notification notification);
	public Task UpdateAsync(Entities.Notification notification);
	public Task<Entities.Notification?> GetByIdAsync(Guid id);
}
