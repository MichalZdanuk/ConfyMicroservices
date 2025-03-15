namespace Shared.Pagination;
public class PaginationResult<TModel>(int pageIndex,
	int pageSize,
	int count,
	IEnumerable<TModel> data)
	where TModel : class
{
	public int PageIndex { get; } = pageIndex;
	public int PageSize { get; } = pageSize;
	public int Count { get; } = count;
	public IEnumerable<TModel> Data { get; } = data;
}
