namespace SGTS.Data.Entities;

public class AsignacionTicket
{
    public int IdAsignacion { get; set; }

    public int IdTicket { get; set; }

    public int IdTecnico { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public DateTime? FechaDesasignacion { get; set; }


    // Navegaciones

    public Ticket Ticket { get; set; } = null!;

    public Usuario Tecnico { get; set; } = null!;
}