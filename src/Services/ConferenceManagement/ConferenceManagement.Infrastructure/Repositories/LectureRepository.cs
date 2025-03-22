using ConferenceManagement.Domain.Data;
using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ConferenceManagement.Infrastructure.Repositories;
public class LectureRepository(ConferenceManagementDbContext context)
	: ILectureRepository
{
	public Task<List<Lecture>> GetLecturesByConferenceIdAsync(Guid conferenceId)
	{
		return context.Lectures.Where(l => l.ConferenceId == conferenceId).ToListAsync();
	}
}
