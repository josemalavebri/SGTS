namespace SGTS.Models.DTOs;

public class TicketDto
{
    public string Titulo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public int IdPrioridad { get; set; }
    public int IdCategoria { get; set; }
}


public class TicketDtoResponse
{
    public int IdTicket { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public string Prioridad { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public string? TecnicoAsignado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }
}