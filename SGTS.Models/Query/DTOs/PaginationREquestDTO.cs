namespace SGTS.Models.Query.DTOs;

public class PaginationRequestDTO
{
    public int Draw { get; set; }
    public int Start { get; set; }
    public int Length { get; set; }
}