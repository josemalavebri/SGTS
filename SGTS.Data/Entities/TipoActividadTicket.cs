namespace SGTS.Data.Entities;

public class TipoActividadTicket
{
    public int IdTipoActividad { get; set; }

    public string Nombre { get; set; } = null!;


    // Navegaciones

    public ICollection<ActividadTicket> Actividades { get; set; }
        = new List<ActividadTicket>();
}