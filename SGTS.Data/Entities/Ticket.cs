namespace SGTS.Data.Entities;

public class Ticket
{
    public int IdTicket { get; set; }
    public int IdUsuario { get; set; }
    public string Descripcion { get; set; }
    public int IdCategoria { get; set; }
    public int IdPrioridad { get; set; }
    public int IdEstado { get; set; }
    public string Titulo { get; set; } = null!;
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaCierre { get; set; }


    // Navegaciones

    public Usuario Usuario { get; set; } = null!;

    public Categoria Categoria { get; set; } = null!;

    public Prioridad Prioridad { get; set; } = null!;

    public Estado Estado { get; set; } = null!;

    public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public ICollection<AsignacionTicket> Asignaciones { get; set; } = new List<AsignacionTicket>();

    public ICollection<ActividadTicket> Actividades { get; set; } = new List<ActividadTicket>();

    public ICollection<Adjunto> Adjuntos { get; set; } = new List<Adjunto>();
}