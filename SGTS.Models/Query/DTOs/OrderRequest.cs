using SGTS.Models.Query.Enums;

namespace SGTS.Models.Query.DTOs;

public class OrderRequestDTO<T>
{
    public T? Column { get; set; }
    public OrderDirection Direction { get; set; }
}