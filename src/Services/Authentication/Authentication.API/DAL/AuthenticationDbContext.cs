using Authentication.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

		base.OnModelCreating(modelBuilder);
	}
}
