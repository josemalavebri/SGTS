namespace SGTS.Data.Entities;

public class TicketHistorialEstado
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }

    public int EstadoTicketId { get; set; }
    public EstadoTicket EstadoTicket { get; set; }

    public int? TecnicoId { get; set; }
    public Usuario Tecnico { get; set; }

    public DateTime FechaCambio { get; set; }
}