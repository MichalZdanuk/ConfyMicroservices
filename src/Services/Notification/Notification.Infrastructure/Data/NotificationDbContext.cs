using MassTransit;
using System.Reflection;

namespace Notification.Infrastructure.Data;
public class NotificationDbContext
	: DbContext
{
	public NotificationDbContext(DbContextOptions<NotificationDbContext> options)
		: base(options)
	{
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Domain.Entities.Notification> Notifications { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.HasDefaultSchema(NotificationMicroservice.DbSchema);

		modelBuilder.AddInboxStateEntity();
		modelBuilder.AddOutboxMessageEntity();
		modelBuilder.AddOutboxStateEntity();

		base.OnModelCreating(modelBuilder);
	}
}
