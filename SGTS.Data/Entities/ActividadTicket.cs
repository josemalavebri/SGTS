namespace SGTS.Data.Entities;

public class ActividadTicket
{
    public int IdActividad { get; set; }

    public int IdTicket { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoActividad { get; set; }

    public DateTime Fecha { get; set; }


    // Navegaciones

    public Ticket Ticket { get; set; } = null!;

    public Usuario Usuario { get; set; } = null!;

    public TipoActividadTicket TipoActividad { get; set; } = null!;
}