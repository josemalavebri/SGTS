namespace SGTS.Data.Entities;

public class Ticket
{
    public int IdTicket { get; set; }

    public int IdUsuario { get; set; }

    public int IdCategoria { get; set; }

    public int IdPrioridad { get; set; }

    public int IdEstado { get; set; }

    public int? TecnicoAsignadoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? FechaCierre { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Usuario? TecnicoAsignado { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Prioridad Prioridad { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Adjunto> Adjuntos { get; set; } = new List<Adjunto>();

    public virtual ICollection<Historial> Historiales { get; set; } = new List<Historial>();
}