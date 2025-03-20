using ConferenceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManagement.Domain.Data;
public interface IDbContext
{
	DbSet<Conference> Conferences { get; }
	DbSet<Lecture> Lectures { get; }
	DbSet<Prelegent> Prelegents { get; }
	DbSet<LectureAssignment> LectureAssignments { get; }

	Task<int> SaveChangesAsync();
}
