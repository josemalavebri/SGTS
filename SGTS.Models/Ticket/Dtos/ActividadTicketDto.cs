namespace SGTS.Models.Ticket.Dtos;

public class ActividadTicketDto
{
    public string Tipo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;
}