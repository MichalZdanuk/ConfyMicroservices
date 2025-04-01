namespace Notification.Domain.Repositories;
public interface INotificationRepository
{
	public Task AddAsync(Entities.Notification notification);
	public Task UpdateAsync(Entities.Notification notification);
	public Task<List<Entities.Notification>> BrowseByUserIdAsync(Guid userId, int pageNumber, int pageSize);
	public Task<int> CountByUserIdAsync(Guid userId);
}
