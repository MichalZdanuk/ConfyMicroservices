using Microsoft.EntityFrameworkCore;
using Notification.Application.Data;
using System.Reflection;

namespace Notification.Infrastructure.Data;
public class NotificationDbContext
	: DbContext, IApplicationDbContext
{
	public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
		: base(options)
	{
	}

	public async Task<int> SaveChangesAsync()
	{
		return await base.SaveChangesAsync();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.HasDefaultSchema(NotificationMicroservice.DbSchema);

		base.OnModelCreating(modelBuilder);
	}
}
