namespace SGTS.Data.Entities;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string? Telefono { get; set; }
    public string PasswordHash { get; set; } = null!;
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Ticket> TicketsCreados { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketsAsignados { get; set; } = new List<Ticket>();

    public virtual UsuarioAsignacion? UsuarioAsignacion  { get; set; } = null!;

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Historial> Historiales { get; set; } = new List<Historial>();
}
