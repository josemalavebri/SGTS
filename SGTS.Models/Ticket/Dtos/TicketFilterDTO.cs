namespace SGTS.Models.Ticket.Dtos;

public class TicketFilterDto
{
    public string? Busqueda { get; set; }
    public int? IdEstado { get; set; }
    public int? IdPrioridad { get; set; }
    public int? IdCategoria { get; set; }
}

