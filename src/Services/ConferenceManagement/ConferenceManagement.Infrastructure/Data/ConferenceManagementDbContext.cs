using ConferenceManagement.Domain.Data;
using ConferenceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConferenceManagement.Infrastructure.Data;
public class ConferenceManagementDbContext
	: DbContext
{
	public ConferenceManagementDbContext(DbContextOptions<ConferenceManagementDbContext> options)
		: base(options)
	{
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Conference> Conferences { get; set; }
	public DbSet<Lecture> Lectures { get; set; }
	public DbSet<Prelegent> Prelegents { get; set; }
	public DbSet<LectureAssignment> LectureAssignments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.HasDefaultSchema(ConferenceManagementMicroservice.DbSchema);

		base.OnModelCreating(modelBuilder);
	}
}
