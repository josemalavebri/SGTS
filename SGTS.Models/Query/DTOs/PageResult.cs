namespace SGTS.Models.Query.DTOs;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = [];

    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public int TotalRecords { get; set; }

    public int TotalRecordsFiltered { get; set; }
}