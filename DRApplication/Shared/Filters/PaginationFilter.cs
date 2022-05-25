namespace DRApplication.Shared.Filters;

public class PaginationFilter
{
    public PaginationFilter() { }
    public PaginationFilter(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize > 25 ? 25: pageSize ;
    }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}