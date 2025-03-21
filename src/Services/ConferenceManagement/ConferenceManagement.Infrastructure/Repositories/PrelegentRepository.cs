using ConferenceManagement.Domain.Entities;
using ConferenceManagement.Domain.Repositories;
using ConferenceManagement.Infrastructure.Data;

namespace ConferenceManagement.Infrastructure.Repositories;
public class PrelegentRepository(ConferenceManagementDbContext context)
	: IPrelegentRepository
{
	public async Task AddPrelegentAsync(Prelegent prelegent)
	{
		await context.Prelegents.AddAsync(prelegent);
	}
}
