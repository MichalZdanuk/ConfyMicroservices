using ConferenceManagement.Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConferenceManagement.Infrastructure.Data;
public class ConferenceManagementDbContext
	: DbContext, IApplicationDbContext
{
	public ConferenceManagementDbContext(DbContextOptions<ConferenceManagementDbContext> options)
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
		modelBuilder.HasDefaultSchema(ConferenceManagementMicroservice.DbSchema);

		base.OnModelCreating(modelBuilder);
	}
}
