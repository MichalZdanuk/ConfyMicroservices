using MassTransit;
using System.Reflection;

namespace Registration.Infrastucture.Data;
public class RegistrationDbContext
	: DbContext
{
	public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
		: base(options)
	{
	}

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
