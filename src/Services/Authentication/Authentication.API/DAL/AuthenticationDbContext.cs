using MassTransit;

namespace Authentication.API.DAL;

public class AuthenticationDbContext : DbContext
{
	public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
	{
	}

	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.HasDefaultSchema(AuthenticationService.DbSchema);

		modelBuilder.AddInboxStateEntity();
		modelBuilder.AddOutboxMessageEntity();
		modelBuilder.AddOutboxStateEntity();

		base.OnModelCreating(modelBuilder);
	}
}
