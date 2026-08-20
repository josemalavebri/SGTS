namespace SGTS.Models.Ticket.Dtos;

public class TicketDto
{
    public string Titulo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public int IdPrioridad { get; set; }
    public int IdCategoria { get; set; }
}