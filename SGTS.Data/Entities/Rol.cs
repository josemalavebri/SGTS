namespace SGTS.Data.Entities;

public class Rol
{
    public int IdRol { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    public virtual ICollection<UsuarioAsignacion> UsuarioAsignaciones { get; set; } = new List<UsuarioAsignacion>();
}
