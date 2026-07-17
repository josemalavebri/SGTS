namespace SGTS.Models.DTOs;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int TotalRecords { get; set; }

    public int TotalRecordsFiltered { get; set; }
}