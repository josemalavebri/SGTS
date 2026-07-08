namespace SGTS.Data.Entities;

public class Usuario
{
    public int IdUsuario { get; set; }
    public int IdDepartamento { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string? Telefono { get; set; }
    public string PasswordHash { get; set; } = null!;
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }

    public virtual Departamento Departamento { get; set; } = null!;

    // Tickets creados por el usuario
    public virtual ICollection<Ticket> TicketsCreados { get; set; } = new List<Ticket>();

    // Tickets asignados como técnico
    public virtual ICollection<Ticket> TicketsAsignados { get; set; } = new List<Ticket>();

    public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Historial> Historiales { get; set; } = new List<Historial>();
}
