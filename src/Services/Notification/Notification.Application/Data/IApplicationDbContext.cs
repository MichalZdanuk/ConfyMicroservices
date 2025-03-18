namespace Notification.Application.Data;
public interface IApplicationDbContext
{
	Task<int> SaveChangesAsync();
}
