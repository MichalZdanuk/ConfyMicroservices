namespace Shared.Pagination;
public class PaginationResult<TModel>(int pageNumber,
	int pageSize,
	int count,
	IEnumerable<TModel> data)
	where TModel : class
{
	public int PageNumber { get; } = pageNumber;
	public int PageSize { get; } = pageSize;
	public int Count { get; } = count;
	public IEnumerable<TModel> Data { get; } = data;
}
