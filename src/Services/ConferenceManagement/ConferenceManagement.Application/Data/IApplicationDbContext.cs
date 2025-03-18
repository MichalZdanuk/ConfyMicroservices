namespace ConferenceManagement.Application.Data;
public interface IApplicationDbContext
{
	Task<int> SaveChangesAsync();
}
