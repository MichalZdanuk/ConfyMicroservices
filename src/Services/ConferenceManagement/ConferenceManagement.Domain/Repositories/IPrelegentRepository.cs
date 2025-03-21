using ConferenceManagement.Domain.Entities;

namespace ConferenceManagement.Domain.Repositories;
public interface IPrelegentRepository
{
	public Task AddPrelegentAsync(Prelegent prelegent);
}
