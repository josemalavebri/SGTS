namespace SGTS.Data.Entities;

public class Historial
{
    public int IdHistorial { get; set; }

    public int IdTicket { get; set; }

    public int IdUsuario { get; set; }

    public string Accion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}