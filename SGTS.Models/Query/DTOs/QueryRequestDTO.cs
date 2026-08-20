namespace SGTS.Models.Query.DTOs;

public class QueryRequestDTO<TOrder, TFilter>
{
    public PaginationRequestDTO? Pagination { get; set; }

    public OrderRequestDTO<TOrder>? Order { get; set; }

    public TFilter? Filters { get; set; }
}