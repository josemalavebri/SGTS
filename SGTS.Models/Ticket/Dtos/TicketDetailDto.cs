namespace SGTS.Models.Ticket.Dtos;

public class TicketDetailDto
{
    public int IdTicket { get; set; }

    public string Titulo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaCierre { get; set; }

    public string Categoria { get; set; } = null!;
    public string Prioridad { get; set; } = null!;
    public string Estado { get; set; } = null!;

    public DateTime? UltimaActualizacion { get; set; }

    public UsuarioTicketDto Solicitante { get; set; } = null!;

    public UsuarioTicketDto? TecnicoAsignado { get; set; }

    public List<ActividadTicketDto> Actividades { get; set; } = [];
}