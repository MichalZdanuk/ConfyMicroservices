namespace Registration.Domain.Entities;
public class Conference : Entity
{
	public DateTime StartDate { get; private set; }
	public DateTime EndDate { get; private set; }
	public string Name { get; private set; } = default!;


	public static Conference Create(Guid id,
		DateTime startDate,
		DateTime endDate,
		string name)
	{
		return new Conference()
		{
			Id = id,
			StartDate = startDate,
			EndDate = endDate,
			Name = name,
		};
	}
}
