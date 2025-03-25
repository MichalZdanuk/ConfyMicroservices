using MassTransit;
using Registration.Domain.Entities;
using System.Reflection;

namespace Registration.Infrastucture.Data;
public class RegistrationDbContext
	: DbContext
{
	public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
		: base(options)
	{
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Conference> Conferences { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.HasDefaultSchema(RegistrationMicroservice.DbSchema);

		modelBuilder.AddInboxStateEntity();
		modelBuilder.AddOutboxMessageEntity();
		modelBuilder.AddOutboxStateEntity();

		base.OnModelCreating(modelBuilder);
	}
}
